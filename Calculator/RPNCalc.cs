using RPN_API.Calculator.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPN_API.Calculator
{
    public class RPNCalc
    {
        List<int> numbers;

        public RPNCalc()
        {
            numbers = new List<int>();
        }

        public void Clear()
        {
            numbers.Clear();
        }

       public void addNumber(int number)
        {
            numbers.Add(number);
        }

       Operator getOperation(string op)
        {
            switch (op)
            {
                case "+":
                    return new Add();
                case "-":
                    return new Sub();
                case "*":
                    return new Mul();
                case "/":
                    return new Div();
                default:
                    throw new InvalidOperationException();
            }
        }

        public void doOperation(string op)
        {
            if (numbers.Count > 2)
            {
                int A = numbers[numbers.Count - 1];
                int B = numbers[numbers.Count - 2];
                try
                {
                    numbers[numbers.Count - 2] = getOperation(op).DoOp(A, B);
                }
                catch (Exception e)
                {
                    throw;
                }
                numbers.RemoveAt(numbers.Count - 1);
            }
            else
                throw new InvalidOperationException();
        }

        void doOperation(Operator op)
        {
            if (numbers.Count > 2)
            {
                int A = numbers[numbers.Count - 1];
                int B = numbers[numbers.Count - 2];
                numbers[numbers.Count - 2] = op.DoOp(A,B);
                numbers.RemoveAt(numbers.Count - 1);
            }
            else
                throw new InvalidOperationException();
        }
    }
}
