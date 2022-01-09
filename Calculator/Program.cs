using System;
using CalculatorV2.Models;

namespace CalculatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var _calculator = new Calculator();

            try
            {
                Console.WriteLine(_calculator.Calculate("1 + 1 "));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }
    }
}
