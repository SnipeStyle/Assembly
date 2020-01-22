﻿using Blamite.Blam.Scripting.Compiler;
using Blamite.IO;
using System.Collections.Generic;

namespace Blamite.Blam.Scripting
{
	/// <summary>
	///     A script file.
	/// </summary>
	public interface IScriptFile
	{
		/// <summary>
		///     Gets the name of the script file.
		/// </summary>
		/// <value>The name of the script file.</value>
		string Name { get; }

		/// <summary>
		///     Gets the raw script text for the script file. Can be null if not available.
		/// </summary>
		/// <value>The raw script text for the script file, or null if not available.</value>
		string Text { get; }

		/// <summary>
		///     Loads the scripts in the file.
		/// </summary>
		/// <param name="reader">The stream to read from.</param>
		/// <returns>The scripts that were loaded.</returns>
		ScriptTable LoadScripts(IReader reader);

		/// <summary>
		///     Saves scripts back to the file.
		/// </summary>
		/// <param name="scripts">The scripts to save.</param>
		/// <param name="stream">The stream to operate on.</param>
		void SaveScripts(ScriptData scripts, IStream stream);

		/// <summary>
		///     Loads the script file's context.
		/// </summary>
		/// <param name="reader">The stream to read from.</param>
		/// <returns>The script file's context, or null if not available.</returns>
		/// <seealso cref="ScriptContext" />
		ScriptContext LoadContext(IReader reader);

		/// <summary>
		///		Retrieves all unique Seat Mappings which were referenced in this map's scripts.
		/// </summary>
		/// <param name="reader">The stream to read from.</param>
		/// <param name="opcode">The ID which identifies Seat mapping expressions.</param>
		/// <returns></returns>
		SortedDictionary<uint, UnitSeatMapping> GetUniqueSeatMappings(IReader reader, ushort opcode);
	}
}