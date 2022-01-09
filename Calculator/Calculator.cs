using System;
using System.Collections.Generic;

namespace CalculatorV2
{
    public interface ICalculator
    {
        double Calculate(string sum);
    }

    public class Calculator : ICalculator
    {
        public Calculator() { }

        private const string STRING_SEPARATOR = " ";
        private const string OPERATOR_DIVIDE = "/";
        private const string OPERATOR_MULTIPLY = "*";
        private const string OPERATOR_ADDITION = "+";
        private const string OPERATOR_SUBTRACTION = "-";
        private const string OPERATOR_OPEN_PARENTHESIS = "(";
        private const string OPERATOR_CLOSE_PARENTHESIS = ")";

        public double Calculate(string sum)
        {
            return CalculateRecursive(sum.Split(STRING_SEPARATOR));
        }

        private double CalculateRecursive(string[] sum)
        {
            var stack = new Stack<string>();

            for (int currentIndex = 0; currentIndex < sum.Length; currentIndex++)
            {
                var _stackCount = stack.Count;
                var _character = sum[currentIndex];

                if (IsOpenParenthesis(_character))
                {
                    (double _parenthesisSum, int _closeParenthesisIndex) =
                        GetParenthesisValue(sum, currentIndex);

                    currentIndex = _closeParenthesisIndex;
                    _character = _parenthesisSum.ToString();
                }

                if (_stackCount == 0)
                {
                    stack.Push(_character);
                    continue;
                }

                var _previousCharacter = stack.Peek();

                if (IsDivideOrMultiplyOperator(_previousCharacter))
                {
                    stack.Pop();
                    var _firstValue = stack.Pop();
                    var _secondValue = _character;

                    CalculateByOperator(stack, _previousCharacter, _firstValue, _secondValue);
                }
                else
                {
                    stack.Push(_character);
                }
            }

            // We need to realign the stack to calculate the sum in order
            var newStack = ReverseStack(stack);

            var _finalAmount = CalculateRemainingSum(newStack);

            return _finalAmount;
        }

        private (double parenthesisSum, int closeParenthesisIndex)
            GetParenthesisValue(string[] sum, int openParenthesisIndex)
        {
            (string _newSum, int _closeParenthesisIndex) =
                        GetStringFromOpenToMatchingCloseParantheses(sum, openParenthesisIndex);

            var _sum = CalculateRecursive(_newSum.Split(STRING_SEPARATOR));

            return (_sum, _closeParenthesisIndex);
        }

        private (string sumStringSubset, int lastParanthesesIndex)
            GetStringFromOpenToMatchingCloseParantheses(string[] sum, int currentParenthesisIndex)
        {
            var _lastParanthesesIndex = GetLastIndexOf(OPERATOR_CLOSE_PARENTHESIS, sum);
            
            var _sumSubString = GetSubStringWithoutParenthesis(sum, currentParenthesisIndex, _lastParanthesesIndex);

            return (_sumSubString, _lastParanthesesIndex);
        }

        private void CalculateByOperator(
            Stack<string> stack, string @operator, string firstVal, string secondVal)
        {
            switch (@operator)
            {
                case OPERATOR_ADDITION:
                    {
                        var _amount = Convert.ToDouble(firstVal) + Convert.ToDouble(secondVal);
                        stack.Push(_amount.ToString());
                        break;
                    }
                case OPERATOR_SUBTRACTION:
                    {
                        var _amount = Convert.ToDouble(firstVal) - Convert.ToDouble(secondVal);
                        stack.Push(_amount.ToString());
                        break;
                    }
                case OPERATOR_DIVIDE:
                    {
                        var _amount = Convert.ToDouble(firstVal) / Convert.ToDouble(secondVal);
                        stack.Push(_amount.ToString());
                        break;
                    }
                case OPERATOR_MULTIPLY:
                    {
                        var _amount = Convert.ToDouble(firstVal) * Convert.ToDouble(secondVal);
                        stack.Push(_amount.ToString());
                        break;
                    }
            }
        }

        private bool IsDivideOrMultiplyOperator(string @operator)
        {
            if (@operator == OPERATOR_DIVIDE ||
                @operator == OPERATOR_MULTIPLY)
            {
                return true;
            }

            return false;
        }

        private bool IsOpenParenthesis(string character)
        {
            if (character == OPERATOR_OPEN_PARENTHESIS)
            {
                return true;
            }

            return false;
        }

        private int GetLastIndexOf(string @operator, string[] sum)
        {
            var _operatorIndex = -1;

            for (int index = 0; index < sum.Length; index++)
            {
                if (sum[index] == @operator)
                {
                    _operatorIndex = index;
                }
            }

            return _operatorIndex;
        }

        private Stack<string> ReverseStack(Stack<string> stack)
        {
            var _tempStack = new Stack<string>();

            while (stack.Count > 0)
            {
                _tempStack.Push(stack.Pop());
            }

            return _tempStack;
        }

        private double CalculateRemainingSum(Stack<string> stack)
        {
            while (stack.Count > 0)
            {
                if (stack.Count == 1)
                {
                    break;
                }

                var _firstValue = stack.Pop();
                var _operator = stack.Pop();
                var _secondValue = stack.Pop();

                CalculateByOperator(stack, _operator, _firstValue, _secondValue);
            }

            return Math.Round(Convert.ToDouble(stack.Pop()), 2);
        }

        private string GetSubStringWithoutParenthesis(string[] sum, int startIndex, int endIndex)
        {
            var _sumSubstring = "";

            for (int index = startIndex + 1; index < endIndex; index++)
            {
                _sumSubstring += sum[index];

                if (index + 1 < endIndex)
                {
                    _sumSubstring += " ";
                }
            }

            return _sumSubstring;
        }
    }
}
