﻿using Blamite.IO;
using System;
using System.CodeDom.Compiler;
using System.Globalization;

namespace Blamite.Blam.Scripting
{
	/// <summary>
	/// A decompiler for blam scripts, contained in cashe files.
	/// </summary>
	public class BlamScriptDecompiler
	{
		private readonly OpcodeLookup _opcodes;
		private readonly ScriptTable _scripts;
		private readonly Endian _endian;
		private readonly IndentedTextWriter _output;
		private bool _cond = false;
		private int _condIndent;

		private enum BranchType
		{
			Call,
			Multiline, // begin, or, and
			CompilerBegin,
			InitialBegin,
			If,
			Cond
		}

		/// <summary>
		///		Creates a decompiler object.
		/// </summary>
		/// <param name="output">The IndendetTextWriter to write to.</param>
		/// <param name="scripts">The Scripting data contained in the map.</param>
		/// <param name="opcodes">Opcode Lookup.</param>
		/// <param name="endian">Endianness of the .map file.</param>
		public BlamScriptDecompiler(IndentedTextWriter output, ScriptTable scripts, OpcodeLookup opcodes, Endian endian)
		{
			_output = output;
			_scripts = scripts;
			_opcodes = opcodes;
			_endian = endian;
		}

		/// <summary>
		/// Decompiles all Globals and Scripts of a map and writes them to an IndentedTextWriter.
		/// </summary>
		/// <param name="showInfo">Option to show additional Information such as indeces.</param>
		public void Decompile(bool showInfo)
		{
			if(_output.InnerWriter.ToString() != "")
			{
				_output.Write("\n\n\n");
			}

			DecompileGlobals(showInfo);
			_output.Write("\n\n\n");
			DecompileScripts(showInfo);
		}

		/// <summary>
		/// Decompiles all Globals of a map and writes them to an IndentedTextWriter.
		/// </summary>
		/// <param name="showInfo">Option to show additional Information such as indeces.</param>
		public void DecompileGlobals(bool showInfo)
		{
			if (_scripts.Globals is null)
			{
				return;
			}

			// write Header.
			WriteComment("GLOBALS");
			_output.WriteLine();

			for(int i = 0; i < _scripts.Globals.Count; i++)
			{
				var glo = _scripts.Globals[i];

				// write global declaration.
				_output.Write("(global {0} {1} ", _opcodes.GetTypeInfo((ushort)glo.Type).Name, glo.Name);

				// write value.
				FollowRootIndex(glo.ExpressionIndex, false, BranchType.Call);

				// write additional Information.
				if (showInfo)
				{
					_output.WriteLine(")\t\t; Index: {0}, Expression Index: {1}", i, glo.ExpressionIndex.Index.ToString());
				}				
				else
				{
					_output.WriteLine(")");
				}
			}
		}

		/// <summary>
		/// Decompiles all Scripts of a map and writes them to an IndentedTextWriter.
		/// </summary>
		/// <param name="showInfo">Option to show additional Information such as indeces.</param>
		public void DecompileScripts(bool showInfo)
		{
			// return if the map doesn't contain scripts.
			if(_scripts.Scripts is null)
			{
				return;
			}
			WriteComment("SCRIPTS");
			_output.WriteLine();

			for (int i = 0; i < _scripts.Scripts.Count; i++)
			{
				Script scr = _scripts.Scripts[i];

				// filter out branch scripts which were generated by the compiler.
				var split = scr.Name.Split(new string[] { "_to_" }, StringSplitOptions.RemoveEmptyEntries);
				if (split.Length == 2)
				{
					if(_scripts.Scripts.Exists(s => s.Name == split[0]) && _scripts.Scripts.Exists(s => s.Name == split[split.Length - 1]))
						continue;
				}
				else if(split.Length == 3)
				{
					string firstTwo = string.Join("_to_", split, 0, 2);
					string lastTwo = string.Join("_to_", split, 1, 2);
					if ((_scripts.Scripts.Exists(s => s.Name == firstTwo) && _scripts.Scripts.Exists(s => s.Name == split[2])) 
						|| (_scripts.Scripts.Exists(s => s.Name == lastTwo) && _scripts.Scripts.Exists(s => s.Name == split[0])))
						continue;
				}
				else if(split.Length == 4)
				{
					string firstHalf = string.Join("_to_", split, 0, 2);
					string secondHalf = string.Join("_to_", split, 2, 2);
					if (_scripts.Scripts.Exists(s => s.Name == firstHalf) && _scripts.Scripts.Exists(s => s.Name == secondHalf))
						continue;
				}

				// write additional information.
				if (showInfo)
				{
					WriteComment($"Index: {i}, Expression Index: {scr.RootExpressionIndex.Index.ToString()}");
				}

				// write script declaration.
				_output.Write("(script {0} {1} {2}", _opcodes.GetScriptTypeName((ushort)scr.ExecutionType),
					_opcodes.GetTypeInfo((ushort)scr.ReturnType).Name, scr.Name);

				// write script parameter declarations.
				if (scr.Parameters.Count > 0)
				{
					_output.Write(" (");
					bool firstParam = true;
					foreach (ScriptParameter param in scr.Parameters)
					{
						if (!firstParam)
							_output.Write(", ");
						_output.Write("{1} {0}", param.Name, _opcodes.GetTypeInfo((ushort)param.Type).Name);
						firstParam = false;
					}
					_output.WriteLine(")");
				}
				else
				{
					_output.WriteLine();
				}

				_output.Indent++;

				// write code.
				FollowRootIndex(scr.RootExpressionIndex, true, BranchType.InitialBegin);

				// close parenthesis
				_output.Indent = 0;
				_output.WriteLine(")");
				_output.WriteLine();
			}
		}

		/// <summary>
		/// Writes a comment to the script file.
		/// </summary>
		/// <param name="comment">The comment to write.</param>
		public void WriteComment(string comment)
		{
			_output.WriteLine("; {0}", comment);
		}


		/// <summary>
		/// The decompiler follows a branch based on a datum index and generates code. Also handles most of the text formatting.
		/// </summary>
		/// <param name="root">The datumn index to follow.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		/// <param name="type">The type of the branch.</param>
		private void FollowRootIndex(DatumIndex root, bool newLine, BranchType type)
		{
			ScriptExpression exp = _scripts.Expressions.FindExpression(root);
			int index = 0;

			// iterate through the branch.
			while(exp != null)
			{
				int startIndent = _output.Indent;
				bool endOfExpression = exp.NextExpression is null;
				bool endOfInlineMultiline = false;

				// Remove the last expression in cond calls, which were added by the compiler.
				if(type == BranchType.Cond && endOfExpression && exp.Type == ScriptExpressionType.Expression && exp.LineNumber == 0)
				{
					return;
				}
				// if: indent the condition if it is a multiline expression.
				else if (type == BranchType.If && index == 1 && IsMultilineExpression(exp))
				{
					_output.WriteLine();
					_output.Indent++;
				}
				// if: indent after the condition.
				else if(type == BranchType.If && index == 2)
				{
					_output.WriteLine();
					_output.Indent++;
				}
				// begin, and, or (multiline): indent after the function name.
				else if(type == BranchType.Multiline && index == 1)
				{
					_output.WriteLine();
					_output.Indent++;
				}
				// cond: indent after the condition.
				else if (type == BranchType.Cond && index == 2)
				{
					_output.WriteLine();
					_output.Indent += 4;
				}
				// make begin, or and if calls always start on a new line.
				else if (type == BranchType.Call && IsMultilineExpression(exp))
				{
					_output.WriteLine();
					_output.Indent++;
					endOfInlineMultiline = true;
				}

				// write code.
				HandleExpression(exp, newLine);

				// insert space between the parameters of calls and script references.
				if ((type == BranchType.Call || type == BranchType.If) && !endOfExpression && !newLine)
				{
					_output.Write(" ");
				}

				// handle the line break after inline multiline expressions and reset the indent.
				if(endOfInlineMultiline && !endOfExpression)
				{
					_output.WriteLine();
					_output.Indent = startIndent;
				}
				// handle the line break after if statements which end on a multiline expression.
				else if(type == BranchType.If && IsMultilineExpression(exp) && endOfExpression)
				{
					_output.WriteLine();
				}

				index++;
				exp = exp.NextExpression;
			}
		}

		/// <summary>
		/// Decides how to handle an expression and which actions to perform based on the expression type.
		/// </summary>
		/// <param name="expression">The expression, which is being handled.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		private void HandleExpression(ScriptExpression expression, bool newLine)
		{
			ushort ifOp = _opcodes.GetFunctionInfo("if")[0].Opcode;
			ushort funcNameOp = _opcodes.GetTypeInfo("function_name").Opcode;
			short clippedtype = (short)((short)expression.Type & 0xFF);

			bool _ = (ScriptExpressionType)clippedtype switch
			{
				ScriptExpressionType.Group when expression.Opcode == ifOp && expression.LineNumber == 0 => GenerateCond(expression, newLine),
				ScriptExpressionType.Group => GenerateGroup(expression, newLine),

				ScriptExpressionType.Expression when expression.ReturnType == funcNameOp => true,
				ScriptExpressionType.Expression => GenerateExpression(expression, newLine),

				ScriptExpressionType.ScriptReference => GenerateScriptReference(expression, newLine),
				ScriptExpressionType.GlobalsReference => GenerateGlobalsReference(expression, newLine),
				ScriptExpressionType.ParameterReference => GenerateParameterReference(expression, newLine),

				_ => throw new NotImplementedException($"The Decompiler encountered an unknown Expression Type: \"{(ScriptExpressionType)clippedtype}\".")
			};
		}

		/// <summary>
		/// The decompiler generates a function group based on an expression.
		/// </summary>
		/// <param name="expression">The group expression.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		/// <returns>Returns true if code was generated.</returns>
		private bool GenerateGroup(ScriptExpression expression, bool newLine)
		{
			DatumIndex nameIndex = new DatumIndex(expression.Value);
			ScriptFunctionInfo info = _opcodes.GetFunctionInfo(expression.Opcode);

			// filter out begin groups which were added by the compiler.
			if (expression.LineNumber == 0)
			{
				if (info.Name == "if")
					throw new Exception("The decompiler failed to catch a cond call.");

				FollowRootIndex(nameIndex, true, BranchType.CompilerBegin);
				return true;
			}

			int startIndent = _output.Indent;

			// write the call's opening parenthesis and name.
			_output.Write($"({info.Name}");

			// handle regular begin calls.
			if (info.Name.StartsWith("begin")|| info.Name == "or" || info.Name == "and" || info.Name == "branch")
			{
				FollowRootIndex(nameIndex, true, BranchType.Multiline);
				_output.Indent = startIndent;
			}
			// handle if calls.
			else if(info.Name == "if")
			{
				FollowRootIndex(nameIndex, false, BranchType.If);
				_output.Indent = startIndent;
			}
			// handle all other (normal) calls.
			else
			{
				FollowRootIndex(nameIndex, false, BranchType.Call);
			}

			// write the call's closing parenthesis.
			_output.Write(")");

			HandleNewLine(newLine);
			return true;
		}

		/// <summary>
		/// The decompiler generates a cond construct based on an expression.
		/// </summary>
		/// <param name="expression">The cond expression.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		/// <returns>Returns true if code was generated.</returns>
		private bool GenerateCond(ScriptExpression expression, bool newLine)
		{
			int startIndent = _output.Indent;

			// Handle the initial con group.
			if (!_cond)
			{
				// indicate that the following expressions are part of a cond construct. 
				_cond = true;
				_condIndent = _output.Indent + 1;


				_output.WriteLine("(cond");

				// increase indent for the first conditional and write the opening parenthesis.
				_output.Indent++;
				_output.Write("(");

				// generate code.
				DatumIndex nameIndex = new DatumIndex(expression.Value);
				FollowRootIndex(nameIndex, false, BranchType.Cond);

				// write the closing parenthesis of the last conditional.
				_output.Indent = startIndent + 1;
				_output.WriteLine(")");

				// write the closing parenthesis of the cond call.
				_output.Indent = startIndent;
				_output.Write(")");

				_cond = false;
			}

			// handle all following conditionals.
			else
			{
				_output.Indent = _condIndent;

				// close the previous cond group and open the current one.
				_output.WriteLine(")");
				_output.Write("(");

				// generate code.
				DatumIndex nameIndex = new DatumIndex(expression.Value);
				FollowRootIndex(nameIndex, false, BranchType.Cond);

				_output.Indent = startIndent;
			}

			HandleNewLine(newLine);
			return true;
		}

		/// <summary>
		/// The decompiler generates a script reference based on an expression.
		/// </summary>
		/// <param name="expression">The script reference expression.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		/// <returns>Returns true if code was generated.</returns>
		private bool GenerateScriptReference(ScriptExpression expression, bool newLine)
		{
			// we need to retrieve the script's name from its function_name expression. Otherwise branch calls will become corrupt.
			DatumIndex nameIndex = new DatumIndex(expression.Value);
			var nameExp =_scripts.Expressions.FindExpression(nameIndex);

			// write the call's opening parenthesis and name.
			_output.Write($"({nameExp.StringValue}");

			// write code
			FollowRootIndex(nameIndex, false, BranchType.Call);

			// write the call's closing parenthesis.
			_output.Write(")");
			HandleNewLine(newLine);
			return true;
		}

		/// <summary>
		/// The decompiler generates a globals reference based on an expression.
		/// </summary>
		/// <param name="expression">The globals reference expression.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		/// <returns>Returns true if code was generated.</returns>
		private bool GenerateGlobalsReference(ScriptExpression expression, bool newLine)
		{
			_output.Write(expression.StringValue);
			HandleNewLine(newLine);
			return true;
		}

		/// <summary>
		/// The decompiler generates a script parameter reference based on an expression.
		/// </summary>
		/// <param name="expression">The parameter reference expression.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		/// <returns>Returns true if code was generated.</returns>
		private bool GenerateParameterReference(ScriptExpression expression, bool newLine)
		{
			_output.Write(expression.StringValue);
			HandleNewLine(newLine);
			return true;
		}

		/// <summary>
		/// The decompiler generates a literal (expression) on an expression.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		/// <returns>Returns true if code was generated.</returns>
		private bool GenerateExpression(ScriptExpression expression, bool newLine)
		{		
			ScriptValueType type = _opcodes.GetTypeInfo(expression.ReturnType);
			ScriptValueType actualType = type;

			// Check if a typecast is occurring
			if (expression.Opcode != 0xFFFF)
			{
				actualType = _opcodes.GetTypeInfo(expression.Opcode);

				if (actualType.Quoted)
				{
					if (expression.Value != 0xFFFFFFFF)
						_output.Write("\"{0}\"", expression.StringValue);
					else
						_output.Write("none");
					return false;
				}
			}

			uint value = GetValue(expression, actualType);
			byte[] val = BitConverter.GetBytes(value);
			string text;

			switch (actualType.Name)
			{
				case "void":
					text = "";
					break;
				case "ai_command_script":
				case "script":
					short index = BitConverter.ToInt16(val, 0);
					text = _scripts.Scripts[index].Name;
					break;
				case "boolean":
					if (BitConverter.ToBoolean(val, 0))
					{
						text = "true";
					}
					else
					{
						text = "false";
					}
					break;
				case "short":
					text = BitConverter.ToInt16(val, 0).ToString();
					break;
				case "long":
					// Signed integer
					int signed = (int)value;
					text = signed.ToString();
					break;
				case "real":
					float fl = BitConverter.ToSingle(val, 0);
					text = fl.ToString("0.0#######", CultureInfo.InvariantCulture);
					break;
					// Enum Types
				case "player":
				case "game_difficulty":
				case "team":
				case "mp_team":
				case "controller":
				case "button_preset":
				case "joystick_preset":
				case "player_color":
				case "player_model_choice":
				case "voice_output_setting":
				case "voice_mask":
				case "subtitle_setting":
				case "actor_type":
				case "model_state":
				case "event":
				case "character_physics":
				case "skull":
				case "firing_point_evaluator":
				case "damage_region":
					string enumValue = actualType.GetEnumValue(value);
					if (enumValue != null)
					{
						text = enumValue;
					}
					else if (expression.Value == 0xFFFFFFFF)
					{
						text = "none";
					}
					else
					{
						throw new NotImplementedException("Unknown Enum Value.");
					}
					break;

				case "ai_line":
				case "unit_seat_mapping":
					if (expression.Value != 0xFFFFFFFF)
					{
						text = expression.StringValue;
					}
					else
					{
						text = "none";
					}
					break;

				default:
					if(expression.Value == 0xFFFFFFFF)
					{
						text = "none";
					}
					else
					{
						throw new NotImplementedException($"Unhandled Return Type: \"{actualType.Name}\".");
					}
						
					break;
			}

			_output.Write(text);
			HandleNewLine(newLine);
			return false;
		}

		/// <summary>
		/// Retrieves an expression's value. Takes endianness into account.
		/// </summary>
		/// <param name="expression">The expression from which the value is being retrieved.</param>
		/// <param name="type">The value type of the expression.</param>
		/// <returns></returns>
		private uint GetValue(ScriptExpression expression, ScriptValueType type)
		{
			if (_endian == Endian.BigEndian)
				return expression.Value >> (32 - (type.Size * 8));
			else
				return expression.Value;
		}

		/// <summary>
		/// Finishes the current line and causes a line break if the next expression begins on a new line.
		/// </summary>
		/// <param name="newLine">Indicates whether the expressions of the branch start on a new line.</param>
		private void HandleNewLine(bool newLine)
		{
			if(newLine)
			{
				_output.WriteLine();
			}
		}

		/// <summary>
		/// Determines whether an expression is a multiline construct.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns>Returns true if the expression is a multiline construct.</returns>
		private bool IsMultilineExpression(ScriptExpression expression)
		{
			if(expression.Type == ScriptExpressionType.Group)
			{
				ScriptFunctionInfo info = _opcodes.GetFunctionInfo(expression.Opcode);
				return info.Name == "if" || info.Name == "or" || info.Name == "and" || info.Name.StartsWith("begin");
			}

			return false;
		}
	}
}
