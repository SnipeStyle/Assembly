//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from f:\Dev\Antlr\BS_Reach.g4 by ANTLR 4.8

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

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class BS_ReachParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, BOOLEAN=6, NONE=7, DAMAGEREGION=8, 
		MODELSTATE=9, VALUETYPE=10, SCRIPTTYPE=11, STRING=12, FLOAT=13, INT=14, 
		LP=15, RP=16, ID=17, TRASH=18;
	public const int
		RULE_hsc = 0, RULE_globalDeclaration = 1, RULE_scriptDeclaration = 2, 
		RULE_scriptParameters = 3, RULE_cond = 4, RULE_branch = 5, RULE_call = 6, 
		RULE_condGroup = 7, RULE_parameter = 8, RULE_scriptID = 9, RULE_callID = 10, 
		RULE_globalReference = 11, RULE_expression = 12, RULE_literal = 13;
	public static readonly string[] ruleNames = {
		"hsc", "globalDeclaration", "scriptDeclaration", "scriptParameters", "cond", 
		"branch", "call", "condGroup", "parameter", "scriptID", "callID", "globalReference", 
		"expression", "literal"
	};

	private static readonly string[] _LiteralNames = {
		null, "'global'", "'script'", "','", "'cond'", "'branch'", null, "'none'", 
		null, null, null, null, null, null, null, "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, "BOOLEAN", "NONE", "DAMAGEREGION", 
		"MODELSTATE", "VALUETYPE", "SCRIPTTYPE", "STRING", "FLOAT", "INT", "LP", 
		"RP", "ID", "TRASH"
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
		public GlobalDeclarationContext[] globalDeclaration() {
			return GetRuleContexts<GlobalDeclarationContext>();
		}
		public GlobalDeclarationContext globalDeclaration(int i) {
			return GetRuleContext<GlobalDeclarationContext>(i);
		}
		public ScriptDeclarationContext[] scriptDeclaration() {
			return GetRuleContexts<ScriptDeclarationContext>();
		}
		public ScriptDeclarationContext scriptDeclaration(int i) {
			return GetRuleContext<ScriptDeclarationContext>(i);
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
			State = 32;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==LP) {
				{
				State = 30;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
				case 1:
					{
					State = 28; globalDeclaration();
					}
					break;
				case 2:
					{
					State = 29; scriptDeclaration();
					}
					break;
				}
				}
				State = 34;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
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

	public partial class GlobalDeclarationContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public GlobalDeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_globalDeclaration; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterGlobalDeclaration(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitGlobalDeclaration(this);
		}
	}

	[RuleVersion(0)]
	public GlobalDeclarationContext globalDeclaration() {
		GlobalDeclarationContext _localctx = new GlobalDeclarationContext(Context, State);
		EnterRule(_localctx, 2, RULE_globalDeclaration);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 35; Match(LP);
			State = 36; Match(T__0);
			State = 37; Match(VALUETYPE);
			State = 38; Match(ID);
			State = 39; expression();
			State = 40; Match(RP);
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

	public partial class ScriptDeclarationContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ITerminalNode SCRIPTTYPE() { return GetToken(BS_ReachParser.SCRIPTTYPE, 0); }
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public ScriptIDContext scriptID() {
			return GetRuleContext<ScriptIDContext>(0);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public ScriptParametersContext scriptParameters() {
			return GetRuleContext<ScriptParametersContext>(0);
		}
		public CallContext[] call() {
			return GetRuleContexts<CallContext>();
		}
		public CallContext call(int i) {
			return GetRuleContext<CallContext>(i);
		}
		public GlobalReferenceContext[] globalReference() {
			return GetRuleContexts<GlobalReferenceContext>();
		}
		public GlobalReferenceContext globalReference(int i) {
			return GetRuleContext<GlobalReferenceContext>(i);
		}
		public BranchContext[] branch() {
			return GetRuleContexts<BranchContext>();
		}
		public BranchContext branch(int i) {
			return GetRuleContext<BranchContext>(i);
		}
		public CondContext[] cond() {
			return GetRuleContexts<CondContext>();
		}
		public CondContext cond(int i) {
			return GetRuleContext<CondContext>(i);
		}
		public ScriptDeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_scriptDeclaration; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterScriptDeclaration(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitScriptDeclaration(this);
		}
	}

	[RuleVersion(0)]
	public ScriptDeclarationContext scriptDeclaration() {
		ScriptDeclarationContext _localctx = new ScriptDeclarationContext(Context, State);
		EnterRule(_localctx, 4, RULE_scriptDeclaration);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 42; Match(LP);
			State = 43; Match(T__1);
			State = 44; Match(SCRIPTTYPE);
			State = 45; Match(VALUETYPE);
			State = 46; scriptID();
			State = 48;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				{
				State = 47; scriptParameters();
				}
				break;
			}
			State = 54;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				State = 54;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
				case 1:
					{
					State = 50; call();
					}
					break;
				case 2:
					{
					State = 51; globalReference();
					}
					break;
				case 3:
					{
					State = 52; branch();
					}
					break;
				case 4:
					{
					State = 53; cond();
					}
					break;
				}
				}
				State = 56;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==LP || _la==ID );
			State = 58; Match(RP);
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

	public partial class ScriptParametersContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ParameterContext[] parameter() {
			return GetRuleContexts<ParameterContext>();
		}
		public ParameterContext parameter(int i) {
			return GetRuleContext<ParameterContext>(i);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public ScriptParametersContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_scriptParameters; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterScriptParameters(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitScriptParameters(this);
		}
	}

	[RuleVersion(0)]
	public ScriptParametersContext scriptParameters() {
		ScriptParametersContext _localctx = new ScriptParametersContext(Context, State);
		EnterRule(_localctx, 6, RULE_scriptParameters);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 60; Match(LP);
			State = 61; parameter();
			State = 66;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2) {
				{
				{
				State = 62; Match(T__2);
				State = 63; parameter();
				}
				}
				State = 68;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 69; Match(RP);
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

	public partial class CondContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public CondGroupContext[] condGroup() {
			return GetRuleContexts<CondGroupContext>();
		}
		public CondGroupContext condGroup(int i) {
			return GetRuleContext<CondGroupContext>(i);
		}
		public CondContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_cond; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterCond(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitCond(this);
		}
	}

	[RuleVersion(0)]
	public CondContext cond() {
		CondContext _localctx = new CondContext(Context, State);
		EnterRule(_localctx, 8, RULE_cond);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 71; Match(LP);
			State = 72; Match(T__3);
			State = 74;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 73; condGroup();
				}
				}
				State = 76;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==LP );
			State = 78; Match(RP);
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
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
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
		EnterRule(_localctx, 10, RULE_branch);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 80; Match(LP);
			State = 81; Match(T__4);
			State = 85;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOLEAN) | (1L << NONE) | (1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << LP) | (1L << ID))) != 0)) {
				{
				{
				State = 82; expression();
				}
				}
				State = 87;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 88; Match(RP);
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
		public CallIDContext callID() {
			return GetRuleContext<CallIDContext>(0);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
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
		EnterRule(_localctx, 12, RULE_call);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 90; Match(LP);
			State = 91; callID();
			State = 95;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOLEAN) | (1L << NONE) | (1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << LP) | (1L << ID))) != 0)) {
				{
				{
				State = 92; expression();
				}
				}
				State = 97;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 98; Match(RP);
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

	public partial class CondGroupContext : ParserRuleContext {
		public ITerminalNode LP() { return GetToken(BS_ReachParser.LP, 0); }
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode RP() { return GetToken(BS_ReachParser.RP, 0); }
		public CondGroupContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_condGroup; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterCondGroup(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitCondGroup(this);
		}
	}

	[RuleVersion(0)]
	public CondGroupContext condGroup() {
		CondGroupContext _localctx = new CondGroupContext(Context, State);
		EnterRule(_localctx, 14, RULE_condGroup);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 100; Match(LP);
			State = 101; expression();
			State = 103;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 102; expression();
				}
				}
				State = 105;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOLEAN) | (1L << NONE) | (1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << LP) | (1L << ID))) != 0) );
			State = 107; Match(RP);
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

	public partial class ParameterContext : ParserRuleContext {
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public ParameterContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_parameter; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterParameter(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitParameter(this);
		}
	}

	[RuleVersion(0)]
	public ParameterContext parameter() {
		ParameterContext _localctx = new ParameterContext(Context, State);
		EnterRule(_localctx, 16, RULE_parameter);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 109; Match(VALUETYPE);
			State = 110; Match(ID);
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
		EnterRule(_localctx, 18, RULE_scriptID);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 112;
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

	public partial class CallIDContext : ParserRuleContext {
		public ScriptIDContext scriptID() {
			return GetRuleContext<ScriptIDContext>(0);
		}
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public CallIDContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_callID; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterCallID(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitCallID(this);
		}
	}

	[RuleVersion(0)]
	public CallIDContext callID() {
		CallIDContext _localctx = new CallIDContext(Context, State);
		EnterRule(_localctx, 20, RULE_callID);
		try {
			State = 116;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case INT:
			case ID:
				EnterOuterAlt(_localctx, 1);
				{
				State = 114; scriptID();
				}
				break;
			case VALUETYPE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 115; Match(VALUETYPE);
				}
				break;
			default:
				throw new NoViableAltException(this);
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

	public partial class GlobalReferenceContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public GlobalReferenceContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_globalReference; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterGlobalReference(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitGlobalReference(this);
		}
	}

	[RuleVersion(0)]
	public GlobalReferenceContext globalReference() {
		GlobalReferenceContext _localctx = new GlobalReferenceContext(Context, State);
		EnterRule(_localctx, 22, RULE_globalReference);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 118; Match(ID);
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

	public partial class ExpressionContext : ParserRuleContext {
		public LiteralContext literal() {
			return GetRuleContext<LiteralContext>(0);
		}
		public CallContext call() {
			return GetRuleContext<CallContext>(0);
		}
		public BranchContext branch() {
			return GetRuleContext<BranchContext>(0);
		}
		public CondContext cond() {
			return GetRuleContext<CondContext>(0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterExpression(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitExpression(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 24, RULE_expression);
		try {
			State = 124;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,11,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 120; literal();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 121; call();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 122; branch();
				}
				break;
			case 4:
				EnterOuterAlt(_localctx, 4);
				{
				State = 123; cond();
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

	public partial class LiteralContext : ParserRuleContext {
		public ITerminalNode INT() { return GetToken(BS_ReachParser.INT, 0); }
		public ITerminalNode FLOAT() { return GetToken(BS_ReachParser.FLOAT, 0); }
		public ITerminalNode STRING() { return GetToken(BS_ReachParser.STRING, 0); }
		public ITerminalNode DAMAGEREGION() { return GetToken(BS_ReachParser.DAMAGEREGION, 0); }
		public ITerminalNode MODELSTATE() { return GetToken(BS_ReachParser.MODELSTATE, 0); }
		public ITerminalNode BOOLEAN() { return GetToken(BS_ReachParser.BOOLEAN, 0); }
		public ITerminalNode ID() { return GetToken(BS_ReachParser.ID, 0); }
		public ITerminalNode NONE() { return GetToken(BS_ReachParser.NONE, 0); }
		public ITerminalNode VALUETYPE() { return GetToken(BS_ReachParser.VALUETYPE, 0); }
		public LiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_literal; } }
		public override void EnterRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.EnterLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IBS_ReachListener typedListener = listener as IBS_ReachListener;
			if (typedListener != null) typedListener.ExitLiteral(this);
		}
	}

	[RuleVersion(0)]
	public LiteralContext literal() {
		LiteralContext _localctx = new LiteralContext(Context, State);
		EnterRule(_localctx, 26, RULE_literal);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 126;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << BOOLEAN) | (1L << NONE) | (1L << DAMAGEREGION) | (1L << MODELSTATE) | (1L << VALUETYPE) | (1L << STRING) | (1L << FLOAT) | (1L << INT) | (1L << ID))) != 0)) ) {
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
		'\x5964', '\x3', '\x14', '\x83', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', '\t', 
		'\xE', '\x4', '\xF', '\t', '\xF', '\x3', '\x2', '\x3', '\x2', '\a', '\x2', 
		'!', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '$', '\v', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x5', '\x4', '\x33', '\n', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x6', '\x4', 
		'\x39', '\n', '\x4', '\r', '\x4', '\xE', '\x4', ':', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', 
		'\x43', '\n', '\x5', '\f', '\x5', '\xE', '\x5', '\x46', '\v', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x6', 
		'\x6', 'M', '\n', '\x6', '\r', '\x6', '\xE', '\x6', 'N', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\a', '\a', 'V', 
		'\n', '\a', '\f', '\a', '\xE', '\a', 'Y', '\v', '\a', '\x3', '\a', '\x3', 
		'\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\a', '\b', '`', '\n', '\b', 
		'\f', '\b', '\xE', '\b', '\x63', '\v', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\t', '\x3', '\t', '\x3', '\t', '\x6', '\t', 'j', '\n', '\t', '\r', 
		'\t', '\xE', '\t', 'k', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', 
		'\x5', '\f', 'w', '\n', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x5', '\xE', '\x7F', '\n', 
		'\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x2', '\x2', '\x10', 
		'\x2', '\x4', '\x6', '\b', '\n', '\f', '\xE', '\x10', '\x12', '\x14', 
		'\x16', '\x18', '\x1A', '\x1C', '\x2', '\x4', '\x4', '\x2', '\x10', '\x10', 
		'\x13', '\x13', '\x5', '\x2', '\b', '\f', '\xE', '\x10', '\x13', '\x13', 
		'\x2', '\x84', '\x2', '\"', '\x3', '\x2', '\x2', '\x2', '\x4', '%', '\x3', 
		'\x2', '\x2', '\x2', '\x6', ',', '\x3', '\x2', '\x2', '\x2', '\b', '>', 
		'\x3', '\x2', '\x2', '\x2', '\n', 'I', '\x3', '\x2', '\x2', '\x2', '\f', 
		'R', '\x3', '\x2', '\x2', '\x2', '\xE', '\\', '\x3', '\x2', '\x2', '\x2', 
		'\x10', '\x66', '\x3', '\x2', '\x2', '\x2', '\x12', 'o', '\x3', '\x2', 
		'\x2', '\x2', '\x14', 'r', '\x3', '\x2', '\x2', '\x2', '\x16', 'v', '\x3', 
		'\x2', '\x2', '\x2', '\x18', 'x', '\x3', '\x2', '\x2', '\x2', '\x1A', 
		'~', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x80', '\x3', '\x2', '\x2', 
		'\x2', '\x1E', '!', '\x5', '\x4', '\x3', '\x2', '\x1F', '!', '\x5', '\x6', 
		'\x4', '\x2', ' ', '\x1E', '\x3', '\x2', '\x2', '\x2', ' ', '\x1F', '\x3', 
		'\x2', '\x2', '\x2', '!', '$', '\x3', '\x2', '\x2', '\x2', '\"', ' ', 
		'\x3', '\x2', '\x2', '\x2', '\"', '#', '\x3', '\x2', '\x2', '\x2', '#', 
		'\x3', '\x3', '\x2', '\x2', '\x2', '$', '\"', '\x3', '\x2', '\x2', '\x2', 
		'%', '&', '\a', '\x11', '\x2', '\x2', '&', '\'', '\a', '\x3', '\x2', '\x2', 
		'\'', '(', '\a', '\f', '\x2', '\x2', '(', ')', '\a', '\x13', '\x2', '\x2', 
		')', '*', '\x5', '\x1A', '\xE', '\x2', '*', '+', '\a', '\x12', '\x2', 
		'\x2', '+', '\x5', '\x3', '\x2', '\x2', '\x2', ',', '-', '\a', '\x11', 
		'\x2', '\x2', '-', '.', '\a', '\x4', '\x2', '\x2', '.', '/', '\a', '\r', 
		'\x2', '\x2', '/', '\x30', '\a', '\f', '\x2', '\x2', '\x30', '\x32', '\x5', 
		'\x14', '\v', '\x2', '\x31', '\x33', '\x5', '\b', '\x5', '\x2', '\x32', 
		'\x31', '\x3', '\x2', '\x2', '\x2', '\x32', '\x33', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\x38', '\x3', '\x2', '\x2', '\x2', '\x34', '\x39', '\x5', 
		'\xE', '\b', '\x2', '\x35', '\x39', '\x5', '\x18', '\r', '\x2', '\x36', 
		'\x39', '\x5', '\f', '\a', '\x2', '\x37', '\x39', '\x5', '\n', '\x6', 
		'\x2', '\x38', '\x34', '\x3', '\x2', '\x2', '\x2', '\x38', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x39', ':', '\x3', '\x2', '\x2', 
		'\x2', ':', '\x38', '\x3', '\x2', '\x2', '\x2', ':', ';', '\x3', '\x2', 
		'\x2', '\x2', ';', '<', '\x3', '\x2', '\x2', '\x2', '<', '=', '\a', '\x12', 
		'\x2', '\x2', '=', '\a', '\x3', '\x2', '\x2', '\x2', '>', '?', '\a', '\x11', 
		'\x2', '\x2', '?', '\x44', '\x5', '\x12', '\n', '\x2', '@', '\x41', '\a', 
		'\x5', '\x2', '\x2', '\x41', '\x43', '\x5', '\x12', '\n', '\x2', '\x42', 
		'@', '\x3', '\x2', '\x2', '\x2', '\x43', '\x46', '\x3', '\x2', '\x2', 
		'\x2', '\x44', '\x42', '\x3', '\x2', '\x2', '\x2', '\x44', '\x45', '\x3', 
		'\x2', '\x2', '\x2', '\x45', 'G', '\x3', '\x2', '\x2', '\x2', '\x46', 
		'\x44', '\x3', '\x2', '\x2', '\x2', 'G', 'H', '\a', '\x12', '\x2', '\x2', 
		'H', '\t', '\x3', '\x2', '\x2', '\x2', 'I', 'J', '\a', '\x11', '\x2', 
		'\x2', 'J', 'L', '\a', '\x6', '\x2', '\x2', 'K', 'M', '\x5', '\x10', '\t', 
		'\x2', 'L', 'K', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\x3', '\x2', '\x2', 
		'\x2', 'N', 'L', '\x3', '\x2', '\x2', '\x2', 'N', 'O', '\x3', '\x2', '\x2', 
		'\x2', 'O', 'P', '\x3', '\x2', '\x2', '\x2', 'P', 'Q', '\a', '\x12', '\x2', 
		'\x2', 'Q', '\v', '\x3', '\x2', '\x2', '\x2', 'R', 'S', '\a', '\x11', 
		'\x2', '\x2', 'S', 'W', '\a', '\a', '\x2', '\x2', 'T', 'V', '\x5', '\x1A', 
		'\xE', '\x2', 'U', 'T', '\x3', '\x2', '\x2', '\x2', 'V', 'Y', '\x3', '\x2', 
		'\x2', '\x2', 'W', 'U', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\x3', '\x2', 
		'\x2', '\x2', 'X', 'Z', '\x3', '\x2', '\x2', '\x2', 'Y', 'W', '\x3', '\x2', 
		'\x2', '\x2', 'Z', '[', '\a', '\x12', '\x2', '\x2', '[', '\r', '\x3', 
		'\x2', '\x2', '\x2', '\\', ']', '\a', '\x11', '\x2', '\x2', ']', '\x61', 
		'\x5', '\x16', '\f', '\x2', '^', '`', '\x5', '\x1A', '\xE', '\x2', '_', 
		'^', '\x3', '\x2', '\x2', '\x2', '`', '\x63', '\x3', '\x2', '\x2', '\x2', 
		'\x61', '_', '\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\x3', '\x2', 
		'\x2', '\x2', '\x62', '\x64', '\x3', '\x2', '\x2', '\x2', '\x63', '\x61', 
		'\x3', '\x2', '\x2', '\x2', '\x64', '\x65', '\a', '\x12', '\x2', '\x2', 
		'\x65', '\xF', '\x3', '\x2', '\x2', '\x2', '\x66', 'g', '\a', '\x11', 
		'\x2', '\x2', 'g', 'i', '\x5', '\x1A', '\xE', '\x2', 'h', 'j', '\x5', 
		'\x1A', '\xE', '\x2', 'i', 'h', '\x3', '\x2', '\x2', '\x2', 'j', 'k', 
		'\x3', '\x2', '\x2', '\x2', 'k', 'i', '\x3', '\x2', '\x2', '\x2', 'k', 
		'l', '\x3', '\x2', '\x2', '\x2', 'l', 'm', '\x3', '\x2', '\x2', '\x2', 
		'm', 'n', '\a', '\x12', '\x2', '\x2', 'n', '\x11', '\x3', '\x2', '\x2', 
		'\x2', 'o', 'p', '\a', '\f', '\x2', '\x2', 'p', 'q', '\a', '\x13', '\x2', 
		'\x2', 'q', '\x13', '\x3', '\x2', '\x2', '\x2', 'r', 's', '\t', '\x2', 
		'\x2', '\x2', 's', '\x15', '\x3', '\x2', '\x2', '\x2', 't', 'w', '\x5', 
		'\x14', '\v', '\x2', 'u', 'w', '\a', '\f', '\x2', '\x2', 'v', 't', '\x3', 
		'\x2', '\x2', '\x2', 'v', 'u', '\x3', '\x2', '\x2', '\x2', 'w', '\x17', 
		'\x3', '\x2', '\x2', '\x2', 'x', 'y', '\a', '\x13', '\x2', '\x2', 'y', 
		'\x19', '\x3', '\x2', '\x2', '\x2', 'z', '\x7F', '\x5', '\x1C', '\xF', 
		'\x2', '{', '\x7F', '\x5', '\xE', '\b', '\x2', '|', '\x7F', '\x5', '\f', 
		'\a', '\x2', '}', '\x7F', '\x5', '\n', '\x6', '\x2', '~', 'z', '\x3', 
		'\x2', '\x2', '\x2', '~', '{', '\x3', '\x2', '\x2', '\x2', '~', '|', '\x3', 
		'\x2', '\x2', '\x2', '~', '}', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\x80', '\x81', '\t', '\x3', '\x2', '\x2', 
		'\x81', '\x1D', '\x3', '\x2', '\x2', '\x2', '\xE', ' ', '\"', '\x32', 
		'\x38', ':', '\x44', 'N', 'W', '\x61', 'k', 'v', '~',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
