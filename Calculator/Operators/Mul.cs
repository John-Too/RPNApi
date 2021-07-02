using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPN_API.Calculator.Operators
{
    public class Mul : Operator
    {
     
            public override int DoOp(int A, int B)
            {
                return (A * B);
            }
      
    }
}
