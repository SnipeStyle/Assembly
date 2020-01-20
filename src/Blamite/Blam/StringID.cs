﻿using Blamite.Serialization;

namespace Blamite.Blam
{
	/// <summary>
	///     A constant ID representing a debug string.
	/// </summary>
	public struct StringID
	{
		/// <summary>
		///     A null stringID.
		/// </summary>
		public static readonly StringID Null = new StringID(0);

		private readonly uint _value;

		/// <summary>
		///     Constructs a new StringID from a set and an index.
		/// </summary>
		/// <param name="nspace">The namespace the stringID belongs to.</param>
		/// <param name="index">The index of the stringID within the set.</param>
		/// <param name="layout">The layout of the stringID.</param>
		public StringID(int nspace, int index, StringIDLayout layout)
			: this(0, nspace, index, layout)
		{
		}

		/// <summary>
		///     Constructs a new StringID from a length, a set, and an index.
		/// </summary>
		/// <param name="length">The length of the string.</param>
		/// <param name="nspace">The namespace the stringID belongs to.</param>
		/// <param name="index">The index of the stringID within the set.</param>
		/// <param name="layout">The layout of the stringID.</param>
		public StringID(int length, int nspace, int index, StringIDLayout layout)
		{
			var shiftedLength = (int) ((length & CreateMask(layout.LengthSize)) << layout.LengthStart);
			var shiftedNamespace = (int) ((nspace & CreateMask(layout.NamespaceSize)) << layout.NamespaceStart);
			var shiftedIndex = (int) ((index & CreateMask(layout.IndexSize)) << layout.IndexStart);
			_value = (uint) (shiftedLength | shiftedNamespace | shiftedIndex);
		}

		/// <summary>
		///     Constructs a new StringID from a 32-bit value.
		/// </summary>
		/// <param name="value">The 32-bit value of the stringID.</param>
		public StringID(uint value)
		{
			_value = value;
		}

		public StringID(ulong value) : this((uint)value) { }

		/// <summary>
		///     The value of the stringID as a 32-bit integer.
		/// </summary>
		public uint Value
		{
			get { return _value; }
		}

		/// <summary>
		///     Gets the length portion of the stringID. Can be 0 for some games.
		/// </summary>
		/// <param name="layout">The stringID layout to use to parse the length.</param>
		/// <returns>The length portion of the stringID.</returns>
		public int GetLength(StringIDLayout layout)
		{
			return (int) ((Value >> layout.LengthStart) & CreateMask(layout.LengthSize));
		}

		/// <summary>
		///     Gets the set that the stringID belongs to.
		/// </summary>
		/// <param name="layout">The stringID layout to use to parse the set.</param>
		/// <returns>The set portion of the stringID.</returns>
		public int GetNamespace(StringIDLayout layout)
		{
			return (int) ((Value >> layout.NamespaceStart) & CreateMask(layout.NamespaceSize));
		}

		/// <summary>
		///     Gets the index of the string within the set.
		/// </summary>
		/// <param name="layout">The stringID layout to use to parse the index.</param>
		/// <returns>The index portion of the stringID.</returns>
		public int GetIndex(StringIDLayout layout)
		{
			return (int) ((Value >> layout.IndexStart) & CreateMask(layout.IndexSize));
		}

		public override bool Equals(object obj)
		{
			return (obj is StringID) && (this == (StringID) obj);
		}

		public override int GetHashCode()
		{
			return (int) Value;
		}

		public static bool operator ==(StringID x, StringID y)
		{
			return (x.Value == y.Value);
		}

		public static bool operator !=(StringID x, StringID y)
		{
			return !(x == y);
		}

		public override string ToString()
		{
			return "0x" + Value.ToString("X8");
		}

		/// <summary>
		///     Creates a bitmask with a given number of bits set to 1 starting from the LSB.
		/// </summary>
		/// <param name="size">The number of 1 bits to include in the mask.</param>
		/// <returns>The mask that was created.</returns>
		private static uint CreateMask(int size)
		{
			return (0xFFFFFFFF >> (32 - size));
		}
	}
}