using RPN_API.Calculator.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPN_API.Calculator
{
    /// <summary>
    /// 
    /// </summary>
    public class RPNCalc
    {
        List<int> numbers;
        /// <summary>
        /// 
        /// </summary>
        public RPNCalc()
        {
            numbers = new List<int>();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            numbers.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
       public void addNumber(int number)
        {
            numbers.Add(number);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        public void doOperation(string op)
        {
            if (numbers.Count >= 2)
            {
                int A = numbers[numbers.Count - 1];
                int B = numbers[numbers.Count - 2];
                try
                {
                    numbers[numbers.Count - 2] = getOperation(op).DoOp(B, A);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        void doOperation(Operator op)
        {
            if (numbers.Count > 2)
            {
                int B = numbers[numbers.Count - 1];
                int A = numbers[numbers.Count - 2];
                numbers[numbers.Count - 2] = op.DoOp(A,B);
                numbers.RemoveAt(numbers.Count - 1);
            }
            else
                throw new InvalidOperationException();
        }
        ///
        internal List<int> GetNumbers()
        {
            return numbers;
        }
    }
}
