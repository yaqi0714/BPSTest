using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class SPDBException : BaseException
    {
        public SPDBException(string message)
            : base(1003, message)
        {
        }
    }
}
