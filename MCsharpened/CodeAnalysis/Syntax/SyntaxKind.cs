namespace MCsharpened.CodeAnalysis.Syntax
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
		IdentifierToken,

        // Keywords
		FalseKeyword,
		TrueKeyword,

        // Expressions
        LietralExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
	}
}