﻿
using MCsharpened.CodeAnalysis.Syntax;

namespace MCsharpened.CodeAnalysis
{
	public sealed class LiteralExpressionSyntax : ExpressionSyntax
	{
		public LiteralExpressionSyntax(SyntaxToken literalToken)
		{
			LiteralToken = literalToken;
		}



		public override SyntaxKind Kind => SyntaxKind.LietralExpression;
		public SyntaxToken LiteralToken { get; }



		public override IEnumerable<SyntaxNode> GetChildren()
		{
			yield return LiteralToken;
		}
	}
}