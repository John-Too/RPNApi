using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPN_API.Calculator.Operators
{
    /// <summary>
    /// 
    /// </summary>
    public class Operator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public virtual int DoOp(int A, int B)
        {
            return (A + B);
        }
    }
}
