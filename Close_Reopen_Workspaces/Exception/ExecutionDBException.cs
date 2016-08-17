using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class ExecutionDBException : BaseException
    {
        public ExecutionDBException(string message)
            : base (1001, message)
        {
        }
    }
}
