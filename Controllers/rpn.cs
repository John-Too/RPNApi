using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPN_API.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN_API.Controllers
{

    [ApiController]
    [Route("rpn/[controller]")]
    public class rpn : ControllerBase
    {
        public static Dictionary<int, RPNCalc> stacks = new Dictionary<int, RPNCalc>();
        int i = 0; // stacks ids increment
        // List Operands
        [HttpGet("rpn/op")]
        public string GetOp()
        {
            return ("+ - * /");
        }

        [HttpDelete("rpn/op/{op}/stack/{strackid}")]
        public void pushToStack(string op, int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.doOperation(op);
        }

        // Create a new Stack
        [HttpPost("rpn/stack")]
        public void AddStack()
        {
            stacks.Add(i, new RPNCalc());
            i++;
        }
        // List Stack
        [HttpGet("rpn/stack")]
        public string GetStacks()
        {
            StringBuilder sb = new StringBuilder();
            int size = stacks.Count();
            int i = 0;
            foreach (var element in stacks)
            {
                sb.Append(element.Key.ToString());
                i++;
                if (i != size)
                    sb.Append(" ");
            }
            return sb.ToString();
        }

        [HttpDelete("rpn/stack/{stackid}")]
        public void deleteStack(int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.Clear();
            stacks.Remove(stackid);
        }

        [HttpDelete("rpn/stack/{stackid}")]
        public void pushToStack(int stackid, int number )
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.addNumber(number);
        }
    }
}
