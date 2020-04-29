using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clearch.Application.Common.Exceptions
{
    public class ClearchException : Exception
    {
        public ClearchException()
        {
        }

        public ClearchException(string message) : base(message)
        {
        }

        public ClearchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClearchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
