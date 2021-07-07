using RPN_API.Calculator.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPN_API.Calculator.OperationFactory
{
    /// <summary>
    /// 
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static Operator getOperation(string op)
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

    }
}
