using System;

namespace CalculatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var _calculator = new Calculator();

            Console.WriteLine(_calculator.Calculate("1 + 1"));
        }
    }
}
