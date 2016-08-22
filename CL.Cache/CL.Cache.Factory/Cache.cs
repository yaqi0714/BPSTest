using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.Cache.Factory
{
    public class Cache
    {
        public static Interface.ICache CreateInstance()
        {
            return new CL.Cache.InProc.Cache();
        }
    }
}
