﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPN_API.Calculator.Operators
{
    public class Operator
    {
        public virtual int DoOp(int A, int B)
        {
            return (A + B);
        }
    }
}