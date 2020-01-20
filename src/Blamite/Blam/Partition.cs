﻿/* Copyright 2012 Aaron Dierking, TJ Tunnell, Jordan Mueller, Alex Reed
 * 
 * This file is part of Blamite.
 * 
 * Blamite is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * Blamite is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Blamite.  If not, see <http://www.gnu.org/licenses/>.
 */

using Blamite.IO;

namespace Blamite.Blam
{
	/// <summary>
	///     Represents a partition in a cache file.
	/// </summary>
	public class Partition
	{
		/// <summary>
		///     Creates a new Partition object, given a base pointer and a size.
		/// </summary>
		/// <param name="basePointer">The pointer to the start of the partition.</param>
		/// <param name="size">The partition's size.</param>
		public Partition(SegmentPointer basePointer, uint size)
		{
			BasePointer = basePointer;
			Size = size;
		}

		/// <summary>
		///     The pointer to the start of the partition. Can be null if the partition is empty.
		/// </summary>
		public SegmentPointer BasePointer { get; set; }

		/// <summary>
		///     The size of the partition.
		/// </summary>
		public uint Size { get; set; }

		/// <summary>
		///     Returns whether the given memory address falls within this partition.
		/// </summary>
		/// <param name="address">The memory address to check.</param>
		public bool Contains(long address)
		{
			return (address >= BasePointer.AsPointer() && address < BasePointer.AsPointer() + Size);
		}
	}
}