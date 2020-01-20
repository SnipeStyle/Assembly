﻿using System;
using System.Collections.Generic;
using System.Linq;
using Blamite.Blam.Resources;
using Blamite.Blam.Util;
using Blamite.Serialization;
using Blamite.IO;

namespace Blamite.Blam.ThirdGen.Structures
{
	public class ThirdGenZoneSetTable : IZoneSetTable
	{
		private readonly MetaAllocator _allocator;
		private readonly EngineDescription _buildInfo;
		private readonly ThirdGenResourceGestalt _gestalt;
		private readonly FileSegmentGroup _metaArea;
		private readonly IPointerExpander _expander;

		public ThirdGenZoneSetTable(ThirdGenResourceGestalt gestalt, IReader reader, FileSegmentGroup metaArea,
			MetaAllocator allocator, EngineDescription buildInfo, IPointerExpander expander)
		{
			_gestalt = gestalt;
			_metaArea = metaArea;
			_allocator = allocator;
			_buildInfo = buildInfo;
			_expander = expander;
			Load(reader);
		}

		/// <summary>
		///     Gets the global zone set. This takes priority over all other zone sets.
		/// </summary>
		public IZoneSet GlobalZoneSet { get; private set; }

		public IZoneSet UnattachedZoneSet { get; private set; }

		public IZoneSet DiscForbiddenZoneSet { get; private set; }

		public IZoneSet DiscAlwaysStreamingZoneSet { get; private set; }

		public IZoneSet RequiredMapVariantsZoneSet { get; private set; }

		public IZoneSet SandboxMapVariantsZoneSet { get; private set; }

		public IZoneSet[] GeneralZoneSets { get; private set; }

		public IZoneSet[] BSPZoneSets { get; private set; }

		public IZoneSet[] BSPZoneSets2 { get; private set; }

		public IZoneSet[] BSPZoneSets3 { get; private set; }

		public IZoneSet[] CinematicZoneSets { get; private set; }

		public IZoneSet[] ScenarioZoneSets { get; private set; }

		/// <summary>
		///		Adjusts the length of the resource arrays for all possible zonesets to fit the given index, if necessary.
		/// </summary>
		/// <param name="index">The index to adjust for.</param>
		public void ExpandAllResources(int index)
		{
			if (GlobalZoneSet != null)
				GlobalZoneSet.ExpandResources(index);
			if (UnattachedZoneSet != null)
				UnattachedZoneSet.ExpandResources(index);
			if (DiscForbiddenZoneSet != null)
				DiscForbiddenZoneSet.ExpandResources(index);
			if (DiscAlwaysStreamingZoneSet != null)
				DiscAlwaysStreamingZoneSet.ExpandResources(index);

			if (RequiredMapVariantsZoneSet != null)
				RequiredMapVariantsZoneSet.ExpandResources(index);
			if (SandboxMapVariantsZoneSet != null)
				SandboxMapVariantsZoneSet.ExpandResources(index);

			if (GeneralZoneSets != null)
				foreach (IZoneSet z in GeneralZoneSets)
					z.ExpandResources(index);
			if (BSPZoneSets != null)
				foreach (IZoneSet z in BSPZoneSets)
					z.ExpandResources(index);
			if (BSPZoneSets2 != null)
				foreach (IZoneSet z in BSPZoneSets2)
					z.ExpandResources(index);
			if (BSPZoneSets3 != null)
				foreach (IZoneSet z in BSPZoneSets3)
					z.ExpandResources(index);
			if (CinematicZoneSets != null)
				foreach (IZoneSet z in CinematicZoneSets)
					z.ExpandResources(index);
			if (ScenarioZoneSets != null)
				foreach (IZoneSet z in ScenarioZoneSets)
					z.ExpandResources(index);
		}

		/// <summary>
		///		Adjusts the length of the tag arrays for all possible zonesets to fit the given index, if necessary.
		/// </summary>
		/// <param name="index">The index to adjust for.</param>
		public void ExpandAllTags(int index)
		{
			if (GlobalZoneSet != null)
				GlobalZoneSet.ExpandTags(index);
			if (UnattachedZoneSet != null)
				UnattachedZoneSet.ExpandTags(index);
			if (DiscForbiddenZoneSet != null)
				DiscForbiddenZoneSet.ExpandTags(index);
			if (DiscAlwaysStreamingZoneSet != null)
				DiscAlwaysStreamingZoneSet.ExpandTags(index);

			if (RequiredMapVariantsZoneSet != null)
				RequiredMapVariantsZoneSet.ExpandTags(index);
			if (SandboxMapVariantsZoneSet != null)
				SandboxMapVariantsZoneSet.ExpandTags(index);

			if (GeneralZoneSets != null)
				foreach (IZoneSet z in GeneralZoneSets)
					z.ExpandTags(index);
			if (BSPZoneSets != null)
				foreach (IZoneSet z in BSPZoneSets)
					z.ExpandTags(index);
			if (BSPZoneSets2 != null)
				foreach (IZoneSet z in BSPZoneSets2)
					z.ExpandTags(index);
			if (BSPZoneSets3 != null)
				foreach (IZoneSet z in BSPZoneSets3)
					z.ExpandTags(index);
			if (CinematicZoneSets != null)
				foreach (IZoneSet z in CinematicZoneSets)
					z.ExpandTags(index);
			if (ScenarioZoneSets != null)
				foreach (IZoneSet z in ScenarioZoneSets)
					z.ExpandTags(index);
		}

		/// <summary>
		///     Saves changes made to zone sets in the table.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void SaveChanges(IStream stream)
		{
			StructureValueCollection tagValues = _gestalt.LoadTag(stream);
			FreeZoneSets(tagValues, stream);

			var cache = new TagBlockCache<int>();
			SaveZoneSetTable(GlobalZoneSet, tagValues, "number of global zone sets", "global zone set table address", cache, stream);
			SaveZoneSetTable(UnattachedZoneSet, tagValues, "number of unattached zone sets", "unattached zone set table address", cache, stream);
			SaveZoneSetTable(DiscForbiddenZoneSet, tagValues, "number of disc forbidden zone sets", "disc forbidden zone set table address", cache, stream);
			SaveZoneSetTable(DiscAlwaysStreamingZoneSet, tagValues, "number of disc always streaming zone sets", "disc always streaming zone set table address", cache, stream);
			SaveZoneSetTable(RequiredMapVariantsZoneSet, tagValues, "number of required map variant zone sets", "required map variant zone set table address", cache, stream);
			SaveZoneSetTable(SandboxMapVariantsZoneSet, tagValues, "number of sandbox map variant zone sets", "sandbox map variant zone set table address", cache, stream);
			SaveZoneSetTable(GeneralZoneSets, tagValues, "number of general zone sets", "general zone set table address", cache, stream);
			SaveZoneSetTable(BSPZoneSets, tagValues, "number of bsp zone sets", "bsp zone set table address", cache, stream);
			SaveZoneSetTable(BSPZoneSets2, tagValues, "number of bsp 2 zone sets", "bsp 2 zone set table address", cache, stream);
			SaveZoneSetTable(BSPZoneSets3, tagValues, "number of bsp 3 zone sets", "bsp 3 zone set table address", cache, stream);
			SaveZoneSetTable(CinematicZoneSets, tagValues, "number of cinematic zone sets", "cinematic zone set table address", cache, stream);
			SaveZoneSetTable(ScenarioZoneSets, tagValues, "number of scenario zone sets", "scenario zone set table address", cache, stream);

			_gestalt.SaveTag(tagValues, stream);
		}

		private void Load(IReader reader)
		{
			StructureValueCollection tagValues = _gestalt.LoadTag(reader);

			// Global, unattached, disc-forbidden, and disc-always-streaming usually only have one entry
			GlobalZoneSet = ReadZoneSetTable(tagValues, "number of global zone sets", "global zone set table address", reader).FirstOrDefault();
			UnattachedZoneSet = ReadZoneSetTable(tagValues, "number of unattached zone sets", "unattached zone set table address", reader).FirstOrDefault();
			DiscForbiddenZoneSet = ReadZoneSetTable(tagValues, "number of disc forbidden zone sets", "disc forbidden zone set table address", reader).FirstOrDefault();
			DiscAlwaysStreamingZoneSet = ReadZoneSetTable(tagValues, "number of disc always streaming zone sets", "disc always streaming zone set table address", reader).FirstOrDefault();
			RequiredMapVariantsZoneSet = ReadZoneSetTable(tagValues, "number of required map variant zone sets", "required map variant zone set table address", reader).FirstOrDefault();
			SandboxMapVariantsZoneSet = ReadZoneSetTable(tagValues, "number of sandbox map variant zone sets", "sandbox map variant zone set table address", reader).FirstOrDefault();

			// Everything else needs to be an array
			GeneralZoneSets = ReadZoneSetTable(tagValues, "number of general zone sets", "general zone set table address", reader).ToArray();
			BSPZoneSets = ReadZoneSetTable(tagValues, "number of bsp zone sets", "bsp zone set table address", reader).ToArray();
			BSPZoneSets2 = ReadZoneSetTable(tagValues, "number of bsp 2 zone sets", "bsp 2 zone set table address", reader).ToArray();
			BSPZoneSets3 = ReadZoneSetTable(tagValues, "number of bsp 3 zone sets", "bsp 3 zone set table address", reader).ToArray();
			CinematicZoneSets = ReadZoneSetTable(tagValues, "number of cinematic zone sets", "cinematic zone set table address", reader).ToArray();
			ScenarioZoneSets = ReadZoneSetTable(tagValues, "number of scenario zone sets", "scenario zone set table address", reader).ToArray();
		}

		private IEnumerable<ThirdGenZoneSet> ReadZoneSetTable(StructureValueCollection tagValues, string countName, string addressName, IReader reader)
		{
			if (!tagValues.HasInteger(countName) || !tagValues.HasInteger(addressName))
				return Enumerable.Empty<ThirdGenZoneSet>();

			var count = (int) tagValues.GetInteger(countName);
			uint address = (uint)tagValues.GetInteger(addressName);

			long expand = _expander.Expand(address);

			StructureLayout layout = _buildInfo.Layouts.GetLayout("zone set definition");
			StructureValueCollection[] entries = TagBlockReader.ReadTagBlock(reader, count, expand, layout, _metaArea);
			return entries.Select(e => new ThirdGenZoneSet(e, reader, _metaArea, _expander));
		}

		private void SaveZoneSetTable(IZoneSet set, StructureValueCollection tagValues, string countName, string addressName, TagBlockCache<int> cache, IStream stream)
		{
			SaveZoneSetTable(new[] {set}, tagValues, countName, addressName, cache, stream);
		}

		private void SaveZoneSetTable(IZoneSet[] sets, StructureValueCollection tagValues, string countName, string addressName, TagBlockCache<int> cache, IStream stream)
		{
			if (!tagValues.HasInteger(countName) || !tagValues.HasInteger(addressName))
				return;

			var count = (int) tagValues.GetInteger(countName);
			if (count != sets.Length)
				throw new InvalidOperationException("Zone set count does not match");

			uint address = (uint)tagValues.GetInteger(addressName);

			long expand = _expander.Expand(address);

			StructureLayout layout = _buildInfo.Layouts.GetLayout("zone set definition");
			List<StructureValueCollection> entries =
				sets.Select(set => ((ThirdGenZoneSet) set).Serialize(stream, _allocator, cache, _expander)).ToList();
			TagBlockWriter.WriteTagBlock(entries, expand, layout, _metaArea, stream);
		}

		private void FreeZoneSets(StructureValueCollection tagValues, IReader reader)
		{
			FreeZoneSetsInTable(tagValues, "number of global zone sets", "global zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of unattached zone sets", "unattached zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of disc forbidden zone sets", "disc forbidden zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of disc always streaming zone sets", "disc always streaming zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of required map variant zone sets", "required map variant zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of sandbox map variant zone sets", "sandbox map variant zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of general zone sets", "general zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of bsp zone sets", "bsp zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of bsp 2 zone sets", "bsp 2 zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of bsp 3 zone sets", "bsp 3 zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of cinematic zone sets", "cinematic zone set table address", reader);
			FreeZoneSetsInTable(tagValues, "number of scenario zone sets", "scenario zone set table address", reader);
		}

		private void FreeZoneSetsInTable(StructureValueCollection tagValues, string countName, string addressName, IReader reader)
		{
			if (!tagValues.HasInteger(countName) || !tagValues.HasInteger(addressName))
				return;

			var count = (int) tagValues.GetInteger(countName);
			uint address = (uint)tagValues.GetInteger(addressName);

			long expand = _expander.Expand(address);

			StructureLayout layout = _buildInfo.Layouts.GetLayout("zone set definition");
			StructureValueCollection[] entries = TagBlockReader.ReadTagBlock(reader, count, expand, layout, _metaArea);
			foreach (StructureValueCollection entry in entries)
				ThirdGenZoneSet.Free(entry, _allocator, _expander);
		}
	}
}