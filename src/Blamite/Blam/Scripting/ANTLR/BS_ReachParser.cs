//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from BS_Reach.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class BS_ReachParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, DAMAGEREGION=15, MODELSTATE=16, 
		BOOLIT=17, VALUETYPE=18, SCRIPTTYPE=19, STRING=20, FLOAT=21, INT=22, ID=23, 
		LP=24, RP=25, COMMENT=26, WS=27;
	public const int
		RULE_hsc = 0, RULE_gloDecl = 1, RULE_scriDecl = 2, RULE_scriptParams = 3, 
		RULE_branch = 4, RULE_call = 5, RULE_scriptID = 6, RULE_funcID = 7, RULE_gloRef = 8, 
		RULE_expr = 9, RULE_retType = 10, RULE_lit = 11;
	public static readonly string[] ruleNames = {
		"hsc", "gloDecl", "scriDecl", "scriptParams", "branch", "call", "scriptID", 
		"funcID", "gloRef", "expr", "retType", "lit"
	};

	private static readonly string[] _LiteralNames = {
		null, "'global'", "'script'", "','", "'branch'", "'!='", "'>='", "'<='", 
		"'*'", "'+'", "'<'", "'-'", "'='", "'>'", "'void'", null, null, null, 
		null, null, null, null, null, null, "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, "DAMAGEREGION", "MODELSTATE", "BOOLIT", "VALUETYPE", 
		"SCRIPTTYPE", "STRING", "FLOAT", "INT", "ID", "LP", "RP", "COMMENT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "BS_Reach.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static BS_ReachParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public BS_ReachParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public BS_ReachParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class HscContext : ParserRuleContext {
		public GloDeclContext[] gloDecl() {
			return GetRuleContexts<GloDeclContext>();
		}
		public GloDeclContext gloDecl(int i) {
			return GetRuleContext<GloDeclContext>(i);
		}
		public ScriDeclContext[] scriDecl() {
			return GetRuleContexts<ScriDeclContext>();
		}
		public ScriDeclContext scriDecl(int i) {
			return GetRuleContext<ScriDeclContext>(i);
		}
		public HscContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_hsc; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterHsc(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitHsc(this);
		}
	}

	[RuleVersion(0)]
	public HscContext hsc() {
		HscContext _localctx = new HscContext(Context, State);
		EnterRule(_localctx, 0, RULE_hsc);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 26;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				State = 26;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
				case 1:
					{
					State = 24; gloDecl();
					}
					break;
				case 2:
					{
					State = 25; scriDecl();
					}
					break;
				}
				}
				State = 28;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==LP );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class GloDeclContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public GloDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_gloDecl; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterGloDecl(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitGloDecl(this);
		}
	}

	[RuleVersion(0)]
	public GloDeclContext gloDecl() {
		GloDeclContext _localctx = new GloDeclContext(Context, State);
		EnterRule(_localctx, 2, RULE_gloDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 30; Match(LP);
			State = 31; Match(T__0);
			State = 32; Match(VALUETYPE);
			State = 33; Match(ID);
			State = 34; expr();
			State = 35; Match(RP);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ScriDeclContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ITerminalNode SCRIPTTYPE() { return GetToken(BS_ReachParser.SCRIPTTYPE, 0); }
		public RetTypeContext retType() {
			return GetRuleContext<RetTypeContext>(0);
		}
		public ScriptIDContext scriptID() {
			return GetRuleContext<ScriptIDContext>(0);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public ScriptParamsContext scriptParams() {
			return GetRuleContext<ScriptParamsContext>(0);
		}
		public CallContext[] call() {
			return GetRuleContexts<CallContext>();
		}
		public CallContext call(int i) {
			return GetRuleContext<CallContext>(i);
		}
		public GloRefContext[] gloRef() {
			return GetRuleContexts<GloRefContext>();
		}
		public GloRefContext gloRef(int i) {
			return GetRuleContext<GloRefContext>(i);
		}
		public BranchContext[] branch() {
			return GetRuleContexts<BranchContext>();
		}
		public BranchContext branch(int i) {
			return GetRuleContext<BranchContext>(i);
		}
		public ScriDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_scriDecl; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterScriDecl(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitScriDecl(this);
		}
	}

	[RuleVersion(0)]
	public ScriDeclContext scriDecl() {
		ScriDeclContext _localctx = new ScriDeclContext(Context, State);
		EnterRule(_localctx, 4, RULE_scriDecl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 37; Match(LP);
			State = 38; Match(T__1);
			State = 39; Match(SCRIPTTYPE);
			State = 40; retType();
			State = 41; scriptID();
			State = 43;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				{
				State = 42; scriptParams();
				}
				break;
			}
			State = 48;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				State = 48;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
				case 1:
					{
					State = 45; call();
					}
					break;
				case 2:
					{
					State = 46; gloRef();
					}
					break;
				case 3:
					{
					State = 47; branch();
					}
					break;
				}
				}
				State = 50;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==ID || _la==LP );
			State = 52; Match(RP);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ScriptParamsContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ITerminalNode[] VALUETYPE() { return GetTokens(BS_ReachParser.VALUETYPE); }
		public ITerminalNode VALUETYPE(int i) {
			return GetToken(BS_ReachParser.VALUETYPE, i);
		}
		public ITerminalNode[] ID() { return GetTokens(BS_ReachParser.ID); }
		public ITerminalNode ID(int i) {
			return GetToken(BS_ReachParser.ID, i);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public ScriptParamsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_scriptParams; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterScriptParams(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitScriptParams(this);
		}
	}

	[RuleVersion(0)]
	public ScriptParamsContext scriptParams() {
		ScriptParamsContext _localctx = new ScriptParamsContext(Context, State);
		EnterRule(_localctx, 6, RULE_scriptParams);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 54; Match(LP);
			State = 55; Match(VALUETYPE);
			State = 56; Match(ID);
			State = 62;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2) {
				{
				{
				State = 57; Match(T__2);
				State = 58; Match(VALUETYPE);
				State = 59; Match(ID);
				}
				}
				State = 64;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 65; Match(RP);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BranchContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public BranchContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_branch; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterBranch(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitBranch(this);
		}
	}

	[RuleVersion(0)]
	public BranchContext branch() {
		BranchContext _localctx = new BranchContext(Context, State);
		EnterRule(_localctx, 8, RULE_branch);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 67; Match(LP);
			State = 68; Match(T__3);
			State = 72;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << BOOLIT) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << ID) | (1L << LP))) != 0)) {
				{
				{
				State = 69; expr();
				}
				}
				State = 74;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 75; Match(RP);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CallContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public FuncIDContext funcID() {
			return GetRuleContext<FuncIDContext>(0);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public CallContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_call; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterCall(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitCall(this);
		}
	}

	[RuleVersion(0)]
	public CallContext call() {
		CallContext _localctx = new CallContext(Context, State);
		EnterRule(_localctx, 10, RULE_call);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77; Match(LP);
			State = 78; funcID();
			State = 82;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << BOOLIT) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << ID) | (1L << LP))) != 0)) {
				{
				{
				State = 79; expr();
				}
				}
				State = 84;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 85; Match(RP);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ScriptIDContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public ITerminalNode INT() { return GetToken(BS_ReachParser.INT, 0); }
		public ScriptIDContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_scriptID; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterScriptID(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitScriptID(this);
		}
	}

	[RuleVersion(0)]
	public ScriptIDContext scriptID() {
		ScriptIDContext _localctx = new ScriptIDContext(Context, State);
		EnterRule(_localctx, 12, RULE_scriptID);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 87;
			_la = TokenStream.LA(1);
			if ( !(_la==INT || _la==ID) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncIDContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public FuncIDContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_funcID; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterFuncID(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitFuncID(this);
		}
	}

	[RuleVersion(0)]
	public FuncIDContext funcID() {
		FuncIDContext _localctx = new FuncIDContext(Context, State);
		EnterRule(_localctx, 14, RULE_funcID);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 89;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7) | (1L << T__8) | (1L << T__9) | (1L << T__10) | (1L << T__11) | (1L << T__12) | (1L << VALUETYPE) | (1L << ID))) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class GloRefContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public GloRefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_gloRef; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterGloRef(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitGloRef(this);
		}
	}

	[RuleVersion(0)]
	public GloRefContext gloRef() {
		GloRefContext _localctx = new GloRefContext(Context, State);
		EnterRule(_localctx, 16, RULE_gloRef);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 91; Match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public LitContext lit() {
			return GetRuleContext<LitContext>(0);
		}
		public CallContext call() {
			return GetRuleContext<CallContext>(0);
		}
		public BranchContext branch() {
			return GetRuleContext<BranchContext>(0);
		}
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitExpr(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		ExprContext _localctx = new ExprContext(Context, State);
		EnterRule(_localctx, 18, RULE_expr);
		try {
			State = 96;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,8,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 93; lit();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 94; call();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 95; branch();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RetTypeContext : ParserRuleContext {
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public RetTypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_retType; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterRetType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitRetType(this);
		}
	}

	[RuleVersion(0)]
	public RetTypeContext retType() {
		RetTypeContext _localctx = new RetTypeContext(Context, State);
		EnterRule(_localctx, 20, RULE_retType);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 98;
			_la = TokenStream.LA(1);
			if ( !(_la==T__13 || _la==VALUETYPE) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LitContext : ParserRuleContext {
		public ITerminalNode INT() { return GetToken(BS_ReachParser.INT, 0); }
		public ITerminalNode FLOAT() { return GetToken(BS_ReachParser.FLOAT, 0); }
		public ITerminalNode STRING() { return GetToken(BS_ReachParser.STRING, 0); }
		public ITerminalNode DAMAGEREGION() { return GetToken(BS_ReachParser.DAMAGEREGION, 0); }
		public ITerminalNode MODELSTATE() { return GetToken(BS_ReachParser.MODELSTATE, 0); }
		public ITerminalNode BOOLIT() { return GetToken(BS_ReachParser.BOOLIT, 0); }
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public LitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_lit; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterLit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitLit(this);
		}
	}

	[RuleVersion(0)]
	public LitContext lit() {
		LitContext _localctx = new LitContext(Context, State);
		EnterRule(_localctx, 22, RULE_lit);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 100;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << BOOLIT) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << ID))) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x1D', 'i', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x3', '\x2', '\x3', 
		'\x2', '\x6', '\x2', '\x1D', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x1E', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x5', '\x4', '.', '\n', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x6', '\x4', '\x33', '\n', 
		'\x4', '\r', '\x4', '\xE', '\x4', '\x34', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\a', '\x5', '?', '\n', '\x5', '\f', '\x5', '\xE', '\x5', 
		'\x42', '\v', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\a', '\x6', 'I', '\n', '\x6', '\f', '\x6', '\xE', 
		'\x6', 'L', '\v', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\a', '\a', 'S', '\n', '\a', '\f', '\a', '\xE', '\a', 
		'V', '\v', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x5', '\v', '\x63', '\n', '\v', '\x3', '\f', '\x3', '\f', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x2', '\x2', '\xE', '\x2', '\x4', 
		'\x6', '\b', '\n', '\f', '\xE', '\x10', '\x12', '\x14', '\x16', '\x18', 
		'\x2', '\x6', '\x3', '\x2', '\x18', '\x19', '\x5', '\x2', '\a', '\xF', 
		'\x14', '\x14', '\x19', '\x19', '\x4', '\x2', '\x10', '\x10', '\x14', 
		'\x14', '\x4', '\x2', '\x11', '\x14', '\x16', '\x19', '\x2', 'g', '\x2', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', '\x4', ' ', '\x3', '\x2', '\x2', '\x2', 
		'\x6', '\'', '\x3', '\x2', '\x2', '\x2', '\b', '\x38', '\x3', '\x2', '\x2', 
		'\x2', '\n', '\x45', '\x3', '\x2', '\x2', '\x2', '\f', 'O', '\x3', '\x2', 
		'\x2', '\x2', '\xE', 'Y', '\x3', '\x2', '\x2', '\x2', '\x10', '[', '\x3', 
		'\x2', '\x2', '\x2', '\x12', ']', '\x3', '\x2', '\x2', '\x2', '\x14', 
		'\x62', '\x3', '\x2', '\x2', '\x2', '\x16', '\x64', '\x3', '\x2', '\x2', 
		'\x2', '\x18', '\x66', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x1D', '\x5', 
		'\x4', '\x3', '\x2', '\x1B', '\x1D', '\x5', '\x6', '\x4', '\x2', '\x1C', 
		'\x1A', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1B', '\x3', '\x2', '\x2', 
		'\x2', '\x1D', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x1C', '\x3', 
		'\x2', '\x2', '\x2', '\x1E', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x1F', 
		'\x3', '\x3', '\x2', '\x2', '\x2', ' ', '!', '\a', '\x1A', '\x2', '\x2', 
		'!', '\"', '\a', '\x3', '\x2', '\x2', '\"', '#', '\a', '\x14', '\x2', 
		'\x2', '#', '$', '\a', '\x19', '\x2', '\x2', '$', '%', '\x5', '\x14', 
		'\v', '\x2', '%', '&', '\a', '\x1B', '\x2', '\x2', '&', '\x5', '\x3', 
		'\x2', '\x2', '\x2', '\'', '(', '\a', '\x1A', '\x2', '\x2', '(', ')', 
		'\a', '\x4', '\x2', '\x2', ')', '*', '\a', '\x15', '\x2', '\x2', '*', 
		'+', '\x5', '\x16', '\f', '\x2', '+', '-', '\x5', '\xE', '\b', '\x2', 
		',', '.', '\x5', '\b', '\x5', '\x2', '-', ',', '\x3', '\x2', '\x2', '\x2', 
		'-', '.', '\x3', '\x2', '\x2', '\x2', '.', '\x32', '\x3', '\x2', '\x2', 
		'\x2', '/', '\x33', '\x5', '\f', '\a', '\x2', '\x30', '\x33', '\x5', '\x12', 
		'\n', '\x2', '\x31', '\x33', '\x5', '\n', '\x6', '\x2', '\x32', '/', '\x3', 
		'\x2', '\x2', '\x2', '\x32', '\x30', '\x3', '\x2', '\x2', '\x2', '\x32', 
		'\x31', '\x3', '\x2', '\x2', '\x2', '\x33', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\x34', '\x32', '\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x35', '\x36', '\x3', '\x2', '\x2', '\x2', '\x36', 
		'\x37', '\a', '\x1B', '\x2', '\x2', '\x37', '\a', '\x3', '\x2', '\x2', 
		'\x2', '\x38', '\x39', '\a', '\x1A', '\x2', '\x2', '\x39', ':', '\a', 
		'\x14', '\x2', '\x2', ':', '@', '\a', '\x19', '\x2', '\x2', ';', '<', 
		'\a', '\x5', '\x2', '\x2', '<', '=', '\a', '\x14', '\x2', '\x2', '=', 
		'?', '\a', '\x19', '\x2', '\x2', '>', ';', '\x3', '\x2', '\x2', '\x2', 
		'?', '\x42', '\x3', '\x2', '\x2', '\x2', '@', '>', '\x3', '\x2', '\x2', 
		'\x2', '@', '\x41', '\x3', '\x2', '\x2', '\x2', '\x41', '\x43', '\x3', 
		'\x2', '\x2', '\x2', '\x42', '@', '\x3', '\x2', '\x2', '\x2', '\x43', 
		'\x44', '\a', '\x1B', '\x2', '\x2', '\x44', '\t', '\x3', '\x2', '\x2', 
		'\x2', '\x45', '\x46', '\a', '\x1A', '\x2', '\x2', '\x46', 'J', '\a', 
		'\x6', '\x2', '\x2', 'G', 'I', '\x5', '\x14', '\v', '\x2', 'H', 'G', '\x3', 
		'\x2', '\x2', '\x2', 'I', 'L', '\x3', '\x2', '\x2', '\x2', 'J', 'H', '\x3', 
		'\x2', '\x2', '\x2', 'J', 'K', '\x3', '\x2', '\x2', '\x2', 'K', 'M', '\x3', 
		'\x2', '\x2', '\x2', 'L', 'J', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\a', 
		'\x1B', '\x2', '\x2', 'N', '\v', '\x3', '\x2', '\x2', '\x2', 'O', 'P', 
		'\a', '\x1A', '\x2', '\x2', 'P', 'T', '\x5', '\x10', '\t', '\x2', 'Q', 
		'S', '\x5', '\x14', '\v', '\x2', 'R', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'S', 'V', '\x3', '\x2', '\x2', '\x2', 'T', 'R', '\x3', '\x2', '\x2', '\x2', 
		'T', 'U', '\x3', '\x2', '\x2', '\x2', 'U', 'W', '\x3', '\x2', '\x2', '\x2', 
		'V', 'T', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\a', '\x1B', '\x2', '\x2', 
		'X', '\r', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\t', '\x2', '\x2', '\x2', 
		'Z', '\xF', '\x3', '\x2', '\x2', '\x2', '[', '\\', '\t', '\x3', '\x2', 
		'\x2', '\\', '\x11', '\x3', '\x2', '\x2', '\x2', ']', '^', '\a', '\x19', 
		'\x2', '\x2', '^', '\x13', '\x3', '\x2', '\x2', '\x2', '_', '\x63', '\x5', 
		'\x18', '\r', '\x2', '`', '\x63', '\x5', '\f', '\a', '\x2', '\x61', '\x63', 
		'\x5', '\n', '\x6', '\x2', '\x62', '_', '\x3', '\x2', '\x2', '\x2', '\x62', 
		'`', '\x3', '\x2', '\x2', '\x2', '\x62', '\x61', '\x3', '\x2', '\x2', 
		'\x2', '\x63', '\x15', '\x3', '\x2', '\x2', '\x2', '\x64', '\x65', '\t', 
		'\x4', '\x2', '\x2', '\x65', '\x17', '\x3', '\x2', '\x2', '\x2', '\x66', 
		'g', '\t', '\x5', '\x2', '\x2', 'g', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\v', '\x1C', '\x1E', '-', '\x32', '\x34', '@', 'J', 'T', '\x62',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
