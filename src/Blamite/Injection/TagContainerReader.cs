﻿using System;
using Blamite.Blam;
using Blamite.Blam.Resources;
using Blamite.IO;

namespace Blamite.Injection
{
	public static class TagContainerReader
	{
		public static TagContainer ReadTagContainer(IReader reader)
		{
			var tags = new TagContainer();

			var containerFile = new ContainerReader(reader);
			if (!containerFile.NextBlock() || containerFile.BlockName != "tagc")
				throw new ArgumentException("Not a valid tag container file");

			containerFile.EnterBlock();
			ReadBlocks(reader, containerFile, tags);
			containerFile.LeaveBlock();

			return tags;
		}

		private static void ReadBlocks(IReader reader, ContainerReader containerFile, TagContainer tags)
		{
			while (containerFile.NextBlock())
			{
				switch (containerFile.BlockName)
				{
					case "data":
						// Data block
						tags.AddDataBlock(ReadDataBlock(reader, containerFile.BlockVersion));
						break;

					case "tag!":
						// Extracted tag
						tags.AddTag(ReadTag(reader, containerFile.BlockVersion));
						break;

					case "ersp":
						// Extracted Raw Resource Page
						tags.AddExtractedResourcePage(ReadExtractedResourcePage(reader, containerFile.BlockVersion));
						break;

					case "rspg":
						// Resource page
						tags.AddResourcePage(ReadResourcePage(reader, containerFile.BlockVersion));
						break;

					case "rsrc":
						// Resource info
						tags.AddResource(ReadResource(reader, containerFile.BlockVersion));
						break;

					case "pdct":
						// Prediction info
						tags.AddPrediction(ReadPrediction(reader, containerFile.BlockVersion));
						break;
				}
			}
		}

		private static DataBlock ReadDataBlock(IReader reader, byte version)
		{
			if (version > 7)
				throw new InvalidOperationException("Unrecognized \"data\" block version");

			// Block data
			uint originalAddress = reader.ReadUInt32();
			int entryCount = (version >= 1) ? reader.ReadInt32() : 1;
			int align = (version >= 3) ? reader.ReadInt32() : 4;
			bool sort = false;
			if (version >= 7)
			{
				byte sortval = reader.ReadByte();
				sort = sortval > 0;
			}
			byte[] data = ReadByteArray(reader);
			var block = new DataBlock(originalAddress, entryCount, align, sort, data);

			// Address fixups
			int numAddressFixups = reader.ReadInt32();
			for (int i = 0; i < numAddressFixups; i++)
			{
				uint dataAddress = reader.ReadUInt32();
				int writeOffset = reader.ReadInt32();
				block.AddressFixups.Add(new DataBlockAddressFixup(dataAddress, writeOffset));
			}

			// Tagref fixups
			int numTagFixups = reader.ReadInt32();
			for (int i = 0; i < numTagFixups; i++)
			{
				var datum = new DatumIndex(reader.ReadUInt32());
				int writeOffset = reader.ReadInt32();
				block.TagFixups.Add(new DataBlockTagFixup(datum, writeOffset));
			}

			// Resource reference fixups
			int numResourceFixups = reader.ReadInt32();
			for (int i = 0; i < numResourceFixups; i++)
			{
				var datum = new DatumIndex(reader.ReadUInt32());
				int writeOffset = reader.ReadInt32();
				block.ResourceFixups.Add(new DataBlockResourceFixup(datum, writeOffset));
			}

			if (version >= 2)
			{
				// StringID fixups
				int numSIDFixups = reader.ReadInt32();
				for (int i = 0; i < numSIDFixups; i++)
				{
					string str = reader.ReadAscii();
					int writeOffset = reader.ReadInt32();
					block.StringIDFixups.Add(new DataBlockStringIDFixup(str, writeOffset));
				}
			}

			if (version >= 4)
			{
				// Shader fixups
				int numShaderFixups = reader.ReadInt32();
				for (int i = 0; i < numShaderFixups; i++)
				{
					int writeOffset = reader.ReadInt32();
					int shaderDataSize = reader.ReadInt32();
					byte[] shaderData = reader.ReadBlock(shaderDataSize);
					block.ShaderFixups.Add(new DataBlockShaderFixup(writeOffset, shaderData));
				}
			}

			if (version >= 5)
			{
				// Unicode string list fixups
				int numUnicListFixups = reader.ReadInt32();
				for (int i = 0; i < numUnicListFixups; i++)
				{
					// Version 5 is buggy and doesn't include a language index :x
					int languageIndex = i;
					if (version >= 6)
						languageIndex = reader.ReadInt32();

					int writeOffset = reader.ReadInt32();
					int numStrings = reader.ReadInt32();
					UnicListFixupString[] strings = new UnicListFixupString[numStrings];
					for (int j = 0; j < numStrings; j++)
					{
						string stringId = reader.ReadAscii();
						string str = reader.ReadUTF8();
						strings[j] = new UnicListFixupString(stringId, str);
					}
					block.UnicListFixups.Add(new DataBlockUnicListFixup(languageIndex, writeOffset, strings));
				}
			}

			if (version >= 7)
			{
				int numInteropFixups = reader.ReadInt32();
				for (int i = 0; i < numInteropFixups; i++)
				{
					uint dataAddress = reader.ReadUInt32();
					int writeOffset = reader.ReadInt32();
					int type = reader.ReadInt32();
					block.InteropFixups.Add(new DataBlockInteropFixup(type, dataAddress, writeOffset));
				}

				int numEffectFixups = reader.ReadInt32();
				for (int i = 0; i < numEffectFixups; i++)
				{
					int index = reader.ReadInt32();
					int writeOffset = reader.ReadInt32();
					int type = reader.ReadInt32();
					int effectDataSize = reader.ReadInt32();
					byte[] effectData = reader.ReadBlock(effectDataSize);
					block.EffectFixups.Add(new DataBlockEffectFixup(type, index, writeOffset, effectData));
				}
			}

			return block;
		}

		private static ExtractedTag ReadTag(IReader reader, byte version)
		{
			if (version > 0)
				throw new InvalidOperationException("Unrecognized \"tag!\" block version");

			var datum = new DatumIndex(reader.ReadUInt32());
			uint address = reader.ReadUInt32();
			int tagGroup = reader.ReadInt32();
			string name = reader.ReadAscii();
			return new ExtractedTag(datum, address, tagGroup, name);
		}

		private static ResourcePage ReadResourcePage(IReader reader, byte version)
		{
			if (version > 1)
				throw new InvalidOperationException("Unrecognized \"rspg\" block version");

			var page = new ResourcePage();
			page.Index = reader.ReadInt32();
			if (version > 0)
				page.Salt = reader.ReadUInt16();
			page.Flags = reader.ReadByte();
			page.FilePath = reader.ReadAscii();
			if (page.FilePath.Length == 0)
				page.FilePath = null;
			page.Offset = reader.ReadInt32();
			page.UncompressedSize = reader.ReadInt32();
			page.CompressionMethod = (ResourcePageCompression) reader.ReadByte();
			page.CompressedSize = reader.ReadInt32();
			page.Checksum = reader.ReadUInt32();
			page.Hash1 = ReadByteArray(reader);
			page.Hash2 = ReadByteArray(reader);
			page.Hash3 = ReadByteArray(reader);
			page.Unknown1 = reader.ReadInt32();
			page.AssetCount = reader.ReadInt32();
			page.Unknown2 = reader.ReadInt32();
			return page;
		}

		private static ExtractedPage ReadExtractedResourcePage(IReader reader, byte version)
		{
			if (version > 0)
				throw new InvalidOperationException("Unrecognized \"ersp\" block version");

			return new ExtractedPage
			{
				ResourcePageIndex = reader.ReadInt32(),
				ExtractedPageData = ReadByteArray(reader)
			};
		}

		private static ExtractedResourceInfo ReadResource(IReader reader, byte version)
		{
			if (version > 2)
				throw new InvalidOperationException("Unrecognized \"rsrc\" block version");

			var originalIndex = new DatumIndex(reader.ReadUInt32());
			var resource = new ExtractedResourceInfo(originalIndex);
			resource.Flags = reader.ReadUInt32();
			resource.Type = reader.ReadAscii();
			if (string.IsNullOrEmpty(resource.Type))
				resource.Type = null;
			resource.Info = ReadByteArray(reader);
			resource.OriginalParentTagIndex = new DatumIndex(reader.ReadUInt32());
			byte hasLocation = reader.ReadByte();
			if (hasLocation != 0)
			{
				resource.Location = new ExtractedResourcePointer();
				resource.Location.OriginalPrimaryPageIndex = reader.ReadInt32();
				resource.Location.PrimaryOffset = reader.ReadInt32();
				if (version > 1)
				{
					var size = reader.ReadInt32();
					if (size != -1)
					{
						ResourceSize newSize = new ResourceSize();
						newSize.Size = size;
						byte partCount = reader.ReadByte();
						for (int i = 0; i < partCount; i++)
						{
							ResourceSizePart newPart = new ResourceSizePart();
							newPart.Offset = reader.ReadInt32();
							newPart.Size = reader.ReadInt32();
							newSize.Parts.Add(newPart);
						}
						resource.Location.PrimarySize = newSize;
					}
					else
						resource.Location.PrimarySize = null;
				}
				else
				{
					resource.Location.PrimarySize = null;
					reader.Skip(4);
				}
					

				resource.Location.OriginalSecondaryPageIndex = reader.ReadInt32();
				resource.Location.SecondaryOffset = reader.ReadInt32();
				if (version > 1)
				{
					var size = reader.ReadInt32();
					if (size != -1)
					{
						ResourceSize newSize = new ResourceSize();
						newSize.Size = size;
						byte partCount = reader.ReadByte();
						for (int i = 0; i < partCount; i++)
						{
							ResourceSizePart newPart = new ResourceSizePart();
							newPart.Offset = reader.ReadInt32();
							newPart.Size = reader.ReadInt32();
							newSize.Parts.Add(newPart);
						}
						resource.Location.SecondarySize = newSize;
					}
					else
						resource.Location.SecondarySize = null;
				}
				else
				{
					resource.Location.SecondarySize = null;
					reader.Skip(4);
				}

				if (version > 1)
				{
					resource.Location.OriginalTertiaryPageIndex = reader.ReadInt32();
					resource.Location.TertiaryOffset = reader.ReadInt32();
					var size = reader.ReadInt32();
					if (size != -1)
					{
						ResourceSize newSize = new ResourceSize();
						newSize.Size = size;
						byte partCount = reader.ReadByte();
						for (int i = 0; i < partCount; i++)
						{
							ResourceSizePart newPart = new ResourceSizePart();
							newPart.Offset = reader.ReadInt32();
							newPart.Size = reader.ReadInt32();
							newSize.Parts.Add(newPart);
						}
						resource.Location.TertiarySize = newSize;
					}
					else
						resource.Location.TertiarySize = null;
				}
			}
			if (version == 1)
			{
				reader.BaseStream.Position += 4;
				resource.ResourceBits = reader.ReadUInt16();
				reader.BaseStream.Position += 2;
			}
			else
			{
				resource.ResourceBits = reader.ReadInt32();
			}
			resource.BaseDefinitionAddress = reader.ReadInt32();

			int numResourceFixups = reader.ReadInt32();
			for (int i = 0; i < numResourceFixups; i++)
			{
				var fixup = new ResourceFixup();
				fixup.Offset = reader.ReadInt32();
				fixup.Address = reader.ReadUInt32();
				resource.ResourceFixups.Add(fixup);
			}

			int numDefinitionFixups = reader.ReadInt32();
			for (int i = 0; i < numDefinitionFixups; i++)
			{
				var fixup = new ResourceDefinitionFixup();
				fixup.Offset = reader.ReadInt32();
				fixup.Type = reader.ReadInt32();
				resource.DefinitionFixups.Add(fixup);
			}

			return resource;
		}

		private static ExtractedResourcePredictionD ReadPrediction(IReader reader, byte version)
		{
			if (version > 0)
				throw new InvalidOperationException("Unrecognized \"pdct\" block version");

			var prediction = new ExtractedResourcePredictionD();

			prediction.OriginalIndex = reader.ReadInt32();
			prediction.OriginalTagIndex = new DatumIndex(reader.ReadUInt32());

			prediction.Unknown1 = reader.ReadInt32();
			prediction.Unknown2 = reader.ReadInt32();

			int cCount = reader.ReadInt32();
			for (int c = 0; c < cCount; c++)
			{
				var expc = new ExtractedResourcePredictionC();

				expc.BEntry = new ExtractedResourcePredictionB();

				int baCount = reader.ReadInt32();
				for (int a = 0; a < baCount; a++)
				{
					ExtractedResourcePredictionA expa = new ExtractedResourcePredictionA();
					expa.OriginalResourceSubIndex = reader.ReadInt32();
					expa.OriginalResourceIndex = new DatumIndex(reader.ReadUInt32());
					expa.OriginalResourceGroup = reader.ReadInt32();
					expa.OriginalResourceName = reader.ReadAscii();
					expc.BEntry.AEntries.Add(expa);
				}
				prediction.CEntries.Add(expc);
			}

			int aCount = reader.ReadInt32();
			for (int a = 0; a < aCount; a++)
			{
				ExtractedResourcePredictionA expa = new ExtractedResourcePredictionA();
				expa.OriginalResourceSubIndex = reader.ReadInt32();
				expa.OriginalResourceIndex = new DatumIndex(reader.ReadUInt32());
				expa.OriginalResourceGroup = reader.ReadInt32();
				expa.OriginalResourceName = reader.ReadAscii();
				prediction.AEntries.Add(expa);
			}

			return prediction;
		}

		private static byte[] ReadByteArray(IReader reader)
		{
			var size = reader.ReadInt32();
			return size <= 0 ? new byte[0] : reader.ReadBlock(size);
		}
	}
}