﻿
namespace MCsharpened.CodeAnalysis
{
	internal sealed class Lexer
	{
		private readonly string _text;
		private int _position;
		private List<String> _diagnostics = new List<string>();

		public Lexer(string text)
		{
			_text = text;
		}

		public IEnumerable<string> Diagnostics => _diagnostics;

		private void Next()
		{
			_position++;
		}

		private char Current
		{
			get
			{
				if (_position >= _text.Length)
					return '\0';

				return _text[_position];
			}
		}

		public SyntaxToken NextToken()
		{
			// <numbers>
			// + - * / ( )
			// <whitespace>

			if (_position >= _text.Length)
				return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);

			if (char.IsDigit(Current))
			{
				var start = _position;

				while (char.IsDigit(Current))
					Next();

				var length = _position - start;
				var text = _text.Substring(start, length);
				if (!int.TryParse(text, out var value))
				{
					_diagnostics.Add($"The number {_text} isn't a valid int32"); // temp solution
				}

				return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);
			}

			if (char.IsWhiteSpace(Current))
			{
				var start = _position;

				while (char.IsWhiteSpace(Current))
					Next();

				var length = _position - start;
				var text = _text.Substring(start, length);
				return new SyntaxToken(SyntaxKind.WhitespaceToken, start, text, null);
			}

			if (Current == '+')
				return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);

			else if (Current == '-')
				return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);

			else if (Current == '*')
				return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);

			else if (Current == '/')
				return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);

			else if (Current == '(')
				return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);

			else if (Current == ')')
				return new SyntaxToken(SyntaxKind.ClosedParenthesisToken, _position++, ")", null);

			_diagnostics.Add($"ERROR: bad character input: '{Current}'");
			return new SyntaxToken(SyntaxKind.ErrorToken, _position++, _text.Substring(_position - 1, 1), null);
		}
	}
}