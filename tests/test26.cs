
using System;
using System.Collections;

namespace Refal.Runtime
{
	public class test26 : RefalBase
	{
		static void Main(string[] args)
		{
			RefalBase.commandLineArguments = args;

			_Go(new PassiveExpression());

			RefalBase.CloseFiles();
		}

		public static PassiveExpression _Go(PassiveExpression expression)
		{
			Pattern pattern1 = new Pattern();
			if (pattern1.Match(expression))
			{
				return PassiveExpression.Build(_Prout(PassiveExpression.Build(_Order(PassiveExpression.Build("f".ToCharArray(), "a".ToCharArray())))));
			};

			throw new RecognitionImpossibleException("Recognition impossible. Last expression: " + expression.ToString());
		}

		private static PassiveExpression _Order(PassiveExpression expression)
		{
			Pattern pattern2 = new Pattern(new SymbolVariable("s.1"), new SymbolVariable("s.2"));
			if (pattern2.Match(expression))
			{
				expression = PassiveExpression.Build(_PreAlph(PassiveExpression.Build(pattern2.GetVariable("s.1"), pattern2.GetVariable("s.2"))));
				{
					Pattern pattern3 = new Pattern(true);
					pattern3.CopyBoundVariables(pattern2);
					if (pattern3.Match(expression))
					{
						return PassiveExpression.Build(pattern3.GetVariable("s.1"), pattern3.GetVariable("s.2"));
					};

					Pattern pattern4 = new Pattern(false);
					pattern4.CopyBoundVariables(pattern2);
					if (pattern4.Match(expression))
					{
						return PassiveExpression.Build(pattern4.GetVariable("s.2"), pattern4.GetVariable("s.1"));
					};

					throw new RecognitionImpossibleException("Recognition impossible. Last expression: " + expression.ToString());
				}
			};

			throw new RecognitionImpossibleException("Recognition impossible. Last expression: " + expression.ToString());
		}

		private static PassiveExpression _PreAlph(PassiveExpression expression)
		{
			Pattern pattern6 = new Pattern(new SymbolVariable("s.1"), new SymbolVariable("s.1"));
			if (pattern6.Match(expression))
			{
				return PassiveExpression.Build(true);
			};

			Pattern pattern7 = new Pattern(new SymbolVariable("s.1"), new SymbolVariable("s.2"));
			if (pattern7.Match(expression))
			{
				expression = PassiveExpression.Build(_Alphabet(PassiveExpression.Build()));
				Pattern pattern8 = new Pattern(new ExpressionVariable("e.A"), new SymbolVariable("s.1"), new ExpressionVariable("e.B"), new SymbolVariable("s.2"), new ExpressionVariable("e.C"));
				pattern8.CopyBoundVariables(pattern7);
				if (pattern8.Match(expression))
				{
					return PassiveExpression.Build(true);
				}
			};

			Pattern pattern9 = new Pattern(new ExpressionVariable("e.Z"));
			if (pattern9.Match(expression))
			{
				return PassiveExpression.Build(false);
			};

			throw new RecognitionImpossibleException("Recognition impossible. Last expression: " + expression.ToString());
		}

		private static PassiveExpression _Alphabet(PassiveExpression expression)
		{
			Pattern pattern10 = new Pattern();
			if (pattern10.Match(expression))
			{
				return PassiveExpression.Build("abcdefghijklmnopqrstuvwxyz".ToCharArray());
			};

			throw new RecognitionImpossibleException("Recognition impossible. Last expression: " + expression.ToString());
		}
	}
}

