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

namespace Blamite.Blam
{
	/// <summary>
	///     Information about a single tag group in a cache file.
	/// </summary>
	public interface ITagGroup
	{
		/// <summary>
		///     The group's magic as a character string constant.
		/// </summary>
		int Magic { get; set; }

		/// <summary>
		///     The parent group's magic, or -1 if none.
		/// </summary>
		int ParentMagic { get; set; }

		/// <summary>
		///     The magic of the parent group's parent, or -1 if none.
		/// </summary>
		int GrandparentMagic { get; set; }

		/// <summary>
		///     The stringID describing the group's purpose, if available.
		/// </summary>
		StringID Description { get; set; }
	}
}