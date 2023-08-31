
namespace MCsharpened.CodeAnalysis
{
	public enum SyntaxKind
	{
		// Tokens
		ErrorToken,
		EndOfFileToken,
		WhitespaceToken,
		NumberToken,
		PlusToken,
		MinusToken,
		StarToken,
		SlashToken,
		OpenParenthesisToken,
		ClosedParenthesisToken,

		// Expressions
		NumberExpression,
		BinaryExpression,
		ParenthesizedExpression
	}
}