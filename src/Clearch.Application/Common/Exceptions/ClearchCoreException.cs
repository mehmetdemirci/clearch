using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clearch.Application.Common.Exceptions
{
    public class ClearchCoreException : Exception
    {
        public ClearchCoreException()
        {
        }

        public ClearchCoreException(string message) : base(message)
        {
        }

        public ClearchCoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClearchCoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
