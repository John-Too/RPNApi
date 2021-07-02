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
    [Route("[controller]")]
    public class rpn : ControllerBase
    {
        public static Dictionary<int, RPNCalc> stacks = new Dictionary<int, RPNCalc>();
        int i = 0; // stacks ids increment
        // GET: List Avaliable Operators
        [HttpGet("op")]
        public string GetOp()
        {
            return ("+ - * /");
        }

        [HttpPost("op/{op}/stack/{strackid}")]
        public void pushToStack(string op, int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.doOperation(op);
        }

        // POST: Create a new Stack
        [HttpPost("stack")]
        public void AddStack()
        {
            stacks.Add(i, new RPNCalc());
            i++;
        }
        // GET: List Stack
        [HttpGet("stack")]
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

        // DELETE: DELETE Stack
        [HttpDelete("stack/{stackid}")]
        public void deleteStack(int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.Clear();
            stacks.Remove(stackid);
        }

        // POST: AddNumber To Stack
        [HttpPost("stack/{stackid}")]
        public void pushToStack(int stackid, [FromBody] int number )
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.addNumber(number);
        }
        // GET: get Stack
        [HttpGet("stack/{stackid}")]
        public string GetStack(int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);
            var nums = st.GetNumbers();
            StringBuilder sb = new StringBuilder();

            int size = nums.Count();
            int i = 0;
            foreach (var element in nums)
            {
                sb.Append(element.ToString());
                i++;
                if (i != size)
                    sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
