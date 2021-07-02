using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RPN_API.Exceptions
{
    /// <summary>
    /// throwed when invalid stack is selected
    /// </summary>
    public class InvalidStackException : Exception
    {
        /// <summary>
    /// ctor
    /// </summary>
        public InvalidStackException()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public InvalidStackException(string message) : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InvalidStackException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected InvalidStackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
