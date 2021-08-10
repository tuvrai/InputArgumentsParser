using System;
using System.Collections.Generic;
using System.Text;

namespace InputArgumentsParser.Exceptions
{

    [Serializable]
    public class IncorrectOptionValueException : Exception
    {

        public IncorrectOptionValueException()
        {
        }
        public IncorrectOptionValueException(string message) : base(message)
        {
        }
        public IncorrectOptionValueException(string message,string source) : base(message)
        {
            Source = source;
        }
        protected IncorrectOptionValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {

        }
    }
}
