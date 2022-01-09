using System;
namespace CalculatorV2.Exceptions
{
    public class AdditionalWhitespaceBetweenCharactersException : Exception
    {
        public AdditionalWhitespaceBetweenCharactersException() : base()
        {
        }

        public AdditionalWhitespaceBetweenCharactersException(string message) : base(message)
        {
        }
    }
}
