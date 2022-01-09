[![Calculator Build](https://github.com/cyyong95/Calculator/actions/workflows/ci.yaml/badge.svg?branch=master)](https://github.com/cyyong95/Calculator/actions/workflows/ci.yaml)

# Calculator

## This is a simple calculator application
This calculator can perform the following features:
- Addition
- Subtraction
- Multiplication
- Division

Problem statement:
We want to find out the correct result based on the input string parameter given to the calculator.

Assumption:
The input string parameter will always consist of numbers and operators separated by spaces.
```
# Sample data
string inputStringParameter = "1 + 1";
string inputStringParameter = "1 * 1 + 1";
string inputStringParameter = "( 11.5 + 15.4 ) + 10.1";
string inputStringParameter = "10 - ( 2 + 3 * ( 7 - 5 ) )";
```

Solution:
To get the solution, we need to break the problem down and solve one thing at a time.
1. Handle calculation without operator order
2. Handle calculation with operator order
3. Handle calculation in brackets and nested brackets

With that in mind, we solve the questions one at a time.
1. **Handle calculation without operator order**  
In a string that only consist of "+" and "-", we will loop through each number and calculate the value based on the operator.


2. **Handle calculation with operator order**  
When we have a string that has "*" or "/", we know that these operators have higher precedence compared to "+" and "-". Therefore, each time we encounter these operators, we need to immediately calculate the previous number and next number.

3. **Handle calculation in brackets and nested brackets**  
If there exist brackets in the string, we will evaluate each matching opening and close parenthesis as it's own substring and return the final amount in string to the previous caller