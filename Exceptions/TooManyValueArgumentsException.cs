using System;
using System.Collections.Generic;
using System.Text;

namespace InputArgumentsParser.Exceptions
{

    [Serializable]
    public class TooManyValueArgumentsException : Exception
    {
        public TooManyValueArgumentsException() { }
        public TooManyValueArgumentsException(string message) : base(message) { }
        public TooManyValueArgumentsException(string message, Exception inner) : base(message, inner) { }

        protected TooManyValueArgumentsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
