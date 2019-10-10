﻿using System;
using Blamite;
using Antlr4.Runtime;
using Blamite.Blam.Scripting.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blamite.Blam.Scripting.Compiler
{
    public class CompilerException: Exception
    {
        public int Line { get; private set; }
        public string Text { get; private set; }

        public CompilerException(string message, BS_ReachParser.LitContext context) : base(message)
        {
            Line = context.Start.Line;
            Text = context.GetText();
        }

        public CompilerException(string message, BS_ReachParser.CallContext context) : base(message)
        {
            Line = context.Start.Line;
            Text = context.funcID().GetText();
        }

        public CompilerException(string message, BS_ReachParser.ScriDeclContext context) : base(message)
        {
            Line = context.Start.Line;
            Text = context.scriptID().GetText();
        }

        public CompilerException(string message, BS_ReachParser.BranchContext context) : base(message)
        {
            Line = context.Start.Line;
            Text = "branch";
        }

        public CompilerException(string message, string text, int line) : base(message)
        {
            Line = line;
            Text = text;
        }
    }
}
