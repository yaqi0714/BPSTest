using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Close_Reopen_Workspaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            CaseDBAccess caseDBAccess = new CaseDBAccess(context);
            

            //try
            //{
            //    caseDBAccess.GetCases();
            //    foreach (Case _case in context.Cases)
            //    {
            //        _case.ProcessWorkspaces();
            //    }
            //}
            //catch (BaseException baseException)
            //{
            //    EventLogger.WriteEventLog(baseException.Message, baseException.ErrorId);
            //}
            //catch(Exception ex)
            //{
            //    EventLogger.WriteEventLog(ex.Message);
            //}
        }
    }
}
