﻿using System.Linq;
using Blamite.Blam.Resources.Models;
using Blamite.Blam.Util;
using Blamite.Serialization;
using Blamite.IO;

namespace Blamite.Blam.ThirdGen.Resources.Models
{
	public class ThirdGenModelRegion : IModelRegion
	{
		public ThirdGenModelRegion(StructureValueCollection values, IReader reader, FileSegmentGroup metaArea,
			EngineDescription buildInfo)
		{
			Load(values, reader, metaArea, buildInfo);
		}

		public StringID Name { get; private set; }

		public IModelPermutation[] Permutations { get; private set; }

		private void Load(StructureValueCollection values, IReader reader, FileSegmentGroup metaArea,
			EngineDescription buildInfo)
		{
			Name = new StringID(values.GetInteger("name stringid"));

			LoadPermutations(values, reader, metaArea, buildInfo);
		}

		private void LoadPermutations(StructureValueCollection values, IReader reader, FileSegmentGroup metaArea,
			EngineDescription buildInfo)
		{
			var count = (int) values.GetInteger("number of permutations");
			uint address = (uint)values.GetInteger("permutation table address");
			StructureLayout layout = buildInfo.Layouts.GetLayout("model permutation");
			StructureValueCollection[] entries = TagBlockReader.ReadTagBlock(reader, count, address, layout, metaArea);

			Permutations = (from entry in entries
				select new ThirdGenModelPermutation(entry)).ToArray();
		}
	}
}