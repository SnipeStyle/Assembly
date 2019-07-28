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
		BOOLIT=17, VALUETYPE=18, SCRIPTTYPE=19, STRING=20, FLOAT=21, INT=22, LP=23, 
		RP=24, ID=25, COMMENT=26, WS=27;
	public const int
		RULE_hsc = 0, RULE_gloDecl = 1, RULE_scriDecl = 2, RULE_scriptParams = 3, 
		RULE_branch = 4, RULE_call = 5, RULE_funcID = 6, RULE_gloRef = 7, RULE_expr = 8, 
		RULE_retType = 9, RULE_lit = 10;
	public static readonly string[] ruleNames = {
		"hsc", "gloDecl", "scriDecl", "scriptParams", "branch", "call", "funcID", 
		"gloRef", "expr", "retType", "lit"
	};

	private static readonly string[] _LiteralNames = {
		null, "'global'", "'script'", "','", "'branch'", "'!='", "'>='", "'<='", 
		"'*'", "'+'", "'<'", "'-'", "'='", "'>'", "'void'", null, null, null, 
		null, null, null, null, null, "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, "DAMAGEREGION", "MODELSTATE", "BOOLIT", "VALUETYPE", 
		"SCRIPTTYPE", "STRING", "FLOAT", "INT", "LP", "RP", "ID", "COMMENT", "WS"
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
			State = 24;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				State = 24;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
				case 1:
					{
					State = 22; gloDecl();
					}
					break;
				case 2:
					{
					State = 23; scriDecl();
					}
					break;
				}
				}
				State = 26;
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
			State = 28; Match(LP);
			State = 29; Match(T__0);
			State = 30; Match(VALUETYPE);
			State = 31; Match(ID);
			State = 32; expr();
			State = 33; Match(RP);
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
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
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
			State = 35; Match(LP);
			State = 36; Match(T__1);
			State = 37; Match(SCRIPTTYPE);
			State = 38; retType();
			State = 39; Match(ID);
			State = 41;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				{
				State = 40; scriptParams();
				}
				break;
			}
			State = 46;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				State = 46;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
				case 1:
					{
					State = 43; call();
					}
					break;
				case 2:
					{
					State = 44; gloRef();
					}
					break;
				case 3:
					{
					State = 45; branch();
					}
					break;
				}
				}
				State = 48;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==LP || _la==ID );
			State = 50; Match(RP);
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
			State = 52; Match(LP);
			State = 53; Match(VALUETYPE);
			State = 54; Match(ID);
			State = 60;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2) {
				{
				{
				State = 55; Match(T__2);
				State = 56; Match(VALUETYPE);
				State = 57; Match(ID);
				}
				}
				State = 62;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 63; Match(RP);
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
			State = 65; Match(LP);
			State = 66; Match(T__3);
			State = 70;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << BOOLIT) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << LP) | (1L << ID))) != 0)) {
				{
				{
				State = 67; expr();
				}
				}
				State = 72;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 73; Match(RP);
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
			State = 75; Match(LP);
			State = 76; funcID();
			State = 80;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << BOOLIT) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << LP) | (1L << ID))) != 0)) {
				{
				{
				State = 77; expr();
				}
				}
				State = 82;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 83; Match(RP);
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
		EnterRule(_localctx, 12, RULE_funcID);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 85;
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
		EnterRule(_localctx, 14, RULE_gloRef);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 87; Match(ID);
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
		EnterRule(_localctx, 16, RULE_expr);
		try {
			State = 92;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,8,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 89; lit();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 90; call();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 91; branch();
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
		EnterRule(_localctx, 18, RULE_retType);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 94;
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
		EnterRule(_localctx, 20, RULE_lit);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 96;
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
		'\x5964', '\x3', '\x1D', '\x65', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x3', '\x2', '\x3', '\x2', '\x6', '\x2', '\x1B', 
		'\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x1C', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x5', '\x4', ',', '\n', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x6', '\x4', '\x31', '\n', '\x4', '\r', '\x4', '\xE', '\x4', 
		'\x32', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', '=', '\n', 
		'\x5', '\f', '\x5', '\xE', '\x5', '@', '\v', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\a', '\x6', 'G', '\n', 
		'\x6', '\f', '\x6', '\xE', '\x6', 'J', '\v', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\a', '\a', 'Q', '\n', '\a', 
		'\f', '\a', '\xE', '\a', 'T', '\v', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x5', '\n', '_', '\n', '\n', '\x3', '\v', '\x3', '\v', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x2', '\x2', '\r', '\x2', '\x4', '\x6', 
		'\b', '\n', '\f', '\xE', '\x10', '\x12', '\x14', '\x16', '\x2', '\x5', 
		'\x5', '\x2', '\a', '\xF', '\x14', '\x14', '\x1B', '\x1B', '\x4', '\x2', 
		'\x10', '\x10', '\x14', '\x14', '\x5', '\x2', '\x11', '\x14', '\x16', 
		'\x18', '\x1B', '\x1B', '\x2', '\x64', '\x2', '\x1A', '\x3', '\x2', '\x2', 
		'\x2', '\x4', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x6', '%', '\x3', '\x2', 
		'\x2', '\x2', '\b', '\x36', '\x3', '\x2', '\x2', '\x2', '\n', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\f', 'M', '\x3', '\x2', '\x2', '\x2', '\xE', 
		'W', '\x3', '\x2', '\x2', '\x2', '\x10', 'Y', '\x3', '\x2', '\x2', '\x2', 
		'\x12', '^', '\x3', '\x2', '\x2', '\x2', '\x14', '`', '\x3', '\x2', '\x2', 
		'\x2', '\x16', '\x62', '\x3', '\x2', '\x2', '\x2', '\x18', '\x1B', '\x5', 
		'\x4', '\x3', '\x2', '\x19', '\x1B', '\x5', '\x6', '\x4', '\x2', '\x1A', 
		'\x18', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1A', '\x3', 
		'\x2', '\x2', '\x2', '\x1C', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\x3', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x1F', '\a', '\x19', '\x2', 
		'\x2', '\x1F', ' ', '\a', '\x3', '\x2', '\x2', ' ', '!', '\a', '\x14', 
		'\x2', '\x2', '!', '\"', '\a', '\x1B', '\x2', '\x2', '\"', '#', '\x5', 
		'\x12', '\n', '\x2', '#', '$', '\a', '\x1A', '\x2', '\x2', '$', '\x5', 
		'\x3', '\x2', '\x2', '\x2', '%', '&', '\a', '\x19', '\x2', '\x2', '&', 
		'\'', '\a', '\x4', '\x2', '\x2', '\'', '(', '\a', '\x15', '\x2', '\x2', 
		'(', ')', '\x5', '\x14', '\v', '\x2', ')', '+', '\a', '\x1B', '\x2', '\x2', 
		'*', ',', '\x5', '\b', '\x5', '\x2', '+', '*', '\x3', '\x2', '\x2', '\x2', 
		'+', ',', '\x3', '\x2', '\x2', '\x2', ',', '\x30', '\x3', '\x2', '\x2', 
		'\x2', '-', '\x31', '\x5', '\f', '\a', '\x2', '.', '\x31', '\x5', '\x10', 
		'\t', '\x2', '/', '\x31', '\x5', '\n', '\x6', '\x2', '\x30', '-', '\x3', 
		'\x2', '\x2', '\x2', '\x30', '.', '\x3', '\x2', '\x2', '\x2', '\x30', 
		'/', '\x3', '\x2', '\x2', '\x2', '\x31', '\x32', '\x3', '\x2', '\x2', 
		'\x2', '\x32', '\x30', '\x3', '\x2', '\x2', '\x2', '\x32', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x33', '\x34', '\x3', '\x2', '\x2', '\x2', '\x34', 
		'\x35', '\a', '\x1A', '\x2', '\x2', '\x35', '\a', '\x3', '\x2', '\x2', 
		'\x2', '\x36', '\x37', '\a', '\x19', '\x2', '\x2', '\x37', '\x38', '\a', 
		'\x14', '\x2', '\x2', '\x38', '>', '\a', '\x1B', '\x2', '\x2', '\x39', 
		':', '\a', '\x5', '\x2', '\x2', ':', ';', '\a', '\x14', '\x2', '\x2', 
		';', '=', '\a', '\x1B', '\x2', '\x2', '<', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '=', '@', '\x3', '\x2', '\x2', '\x2', '>', '<', '\x3', '\x2', '\x2', 
		'\x2', '>', '?', '\x3', '\x2', '\x2', '\x2', '?', '\x41', '\x3', '\x2', 
		'\x2', '\x2', '@', '>', '\x3', '\x2', '\x2', '\x2', '\x41', '\x42', '\a', 
		'\x1A', '\x2', '\x2', '\x42', '\t', '\x3', '\x2', '\x2', '\x2', '\x43', 
		'\x44', '\a', '\x19', '\x2', '\x2', '\x44', 'H', '\a', '\x6', '\x2', '\x2', 
		'\x45', 'G', '\x5', '\x12', '\n', '\x2', '\x46', '\x45', '\x3', '\x2', 
		'\x2', '\x2', 'G', 'J', '\x3', '\x2', '\x2', '\x2', 'H', '\x46', '\x3', 
		'\x2', '\x2', '\x2', 'H', 'I', '\x3', '\x2', '\x2', '\x2', 'I', 'K', '\x3', 
		'\x2', '\x2', '\x2', 'J', 'H', '\x3', '\x2', '\x2', '\x2', 'K', 'L', '\a', 
		'\x1A', '\x2', '\x2', 'L', '\v', '\x3', '\x2', '\x2', '\x2', 'M', 'N', 
		'\a', '\x19', '\x2', '\x2', 'N', 'R', '\x5', '\xE', '\b', '\x2', 'O', 
		'Q', '\x5', '\x12', '\n', '\x2', 'P', 'O', '\x3', '\x2', '\x2', '\x2', 
		'Q', 'T', '\x3', '\x2', '\x2', '\x2', 'R', 'P', '\x3', '\x2', '\x2', '\x2', 
		'R', 'S', '\x3', '\x2', '\x2', '\x2', 'S', 'U', '\x3', '\x2', '\x2', '\x2', 
		'T', 'R', '\x3', '\x2', '\x2', '\x2', 'U', 'V', '\a', '\x1A', '\x2', '\x2', 
		'V', '\r', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\t', '\x2', '\x2', '\x2', 
		'X', '\xF', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\a', '\x1B', '\x2', 
		'\x2', 'Z', '\x11', '\x3', '\x2', '\x2', '\x2', '[', '_', '\x5', '\x16', 
		'\f', '\x2', '\\', '_', '\x5', '\f', '\a', '\x2', ']', '_', '\x5', '\n', 
		'\x6', '\x2', '^', '[', '\x3', '\x2', '\x2', '\x2', '^', '\\', '\x3', 
		'\x2', '\x2', '\x2', '^', ']', '\x3', '\x2', '\x2', '\x2', '_', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '`', '\x61', '\t', '\x3', '\x2', '\x2', '\x61', 
		'\x15', '\x3', '\x2', '\x2', '\x2', '\x62', '\x63', '\t', '\x4', '\x2', 
		'\x2', '\x63', '\x17', '\x3', '\x2', '\x2', '\x2', '\v', '\x1A', '\x1C', 
		'+', '\x30', '\x32', '>', 'H', 'R', '^',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
