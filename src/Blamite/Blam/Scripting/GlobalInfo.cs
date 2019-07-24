﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blamite.Blam.Scripting
{
    public class GlobalInfo
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GlobalInfo" /> class.
        /// </summary>
        /// <param name="name">The name of the global.</param>
        /// <param name="opcode">The opcode of the global.</param>
        /// <param name="returnType">The return type of the global.</param>
        public GlobalInfo(string name, ushort opcode, string returnType)
        {
            Name = name;
            ReturnType = returnType;
            Opcode = opcode;
            MaskedOpcode = (ushort)(opcode | 0x8000);
        }

        /// <summary>
        ///     Gets the name of the global.
        /// </summary>
        /// <value>The name of the function.</value>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets the return type of the global.
        /// </summary>
        /// <value>The return type of the function.</value>
        public string ReturnType { get; private set; }

        /// <summary>
        ///     Gets the opcode of the global.
        /// </summary>
        /// <value>The opcode of the function.</value>
        public ushort Opcode { get; private set; }

        /// <summary>
        ///     Gets the masked opcode of the global.
        /// </summary>
        /// <value>The opcode of the function.</value>
        public ushort MaskedOpcode { get; private set; }
    }
}