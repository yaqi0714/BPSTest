using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class Context
    {
       public List<Case> Cases { get; set; }

        public Context()
        {
            Cases = new List<Case>();
        }
    }
}
