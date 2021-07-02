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
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class rpn : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<int, RPNCalc> stacks = new Dictionary<int, RPNCalc>();
        static int i = 0; 

        /// <summary>
        ///  List Avaliable Operators
        /// </summary>
        [HttpGet("op")]
        public string GetOp()
        {
            return ("+ - * /");
        }
        /// <summary>
        /// Add operator to stack
        /// </summary>
        [HttpPost("op/{op}/stack/{strackid}")]
        public void pushToStack(string op, int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.doOperation(op);
        }
        /// <summary>
        /// Create a new Stack
        /// </summary>
        [HttpPost("stack")]
        public void AddStack()
        {
            stacks.Add(i, new RPNCalc());
            i++;
        }
        /// <summary>
        /// List Stack
        /// </summary>
        [HttpGet("stack")]
        public string GetStacks()
        {
            StringBuilder sb = new StringBuilder();
            int size = stacks.Count();
            int j = 0;
            foreach (var element in stacks)
            {
                sb.Append(element.Key.ToString());
                j++;
                if (j != size)
                    sb.Append(" ");
            }
            return sb.ToString();
        }
        /// <summary>
        /// DELETE Stack
        /// </summary>
        [HttpDelete("stack/{stackid}")]
        public void deleteStack(int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.Clear();
            stacks.Remove(stackid);
        }
        /// <summary>
        /// AddNumber To Stack
        /// </summary>
        [HttpPost("stack/{stackid}")]
        public void pushToStack(int stackid, [FromBody] int number )
        {
            var st = stacks.GetValueOrDefault(stackid);

            st.addNumber(number);
        }
        /// <summary>
        /// Get Stack
        /// <summary>
        [HttpGet("stack/{stackid}")]
        public string GetStack(int stackid)
        {
            var st = stacks.GetValueOrDefault(stackid);
            if (st == null)
            {
                throw new RPN_API.Exceptions.InvalidStackException(); 
            }
            var nums = st.GetNumbers();
            StringBuilder sb = new StringBuilder();

            int size = nums.Count();
            int j = 0;
            foreach (var element in nums)
            {
                sb.Append(element.ToString());
                j++;
                if (j != size)
                    sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
