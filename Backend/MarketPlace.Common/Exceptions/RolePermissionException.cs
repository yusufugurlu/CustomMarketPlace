using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Common.Exceptions
{
    public class RolePermissionException : Exception
    {
        public RolePermissionException()
        {
        }

        public RolePermissionException(string message)
            : base(message)
        {
        }

        public RolePermissionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
