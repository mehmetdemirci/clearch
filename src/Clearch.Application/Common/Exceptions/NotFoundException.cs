using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Application.Common.Exceptions
{
    public class NotFoundException : ClearchCoreException
    {
        public NotFoundException(string name, object key)
            : base($"Entity '{name}' ({key}) was not found.")
        {
        }
    }
}
