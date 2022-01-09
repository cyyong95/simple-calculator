using System;
namespace CalculatorV2.Exceptions
{
    public class UnevenParenthesisException : Exception
    {
        public UnevenParenthesisException() : base()
        {
        }

        public UnevenParenthesisException(string message) : base(message)
        {
        }
    }
}
