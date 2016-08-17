using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class CaseDBException : BaseException
    {
        public CaseDBException(string message)
            : base(1002, message)
        {
        }
    }
}
