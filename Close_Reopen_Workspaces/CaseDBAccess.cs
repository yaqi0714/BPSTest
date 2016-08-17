using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Close_Reopen_Workspaces
{
    class CaseDBAccess
    {
        protected Context context;

        protected CaseBuilder builder;

        public CaseDBAccess(Context _context)
        {
            this.context = _context;

            this.builder = new CaseBuilder(context);

        }
       
        public void GetCases()
        {
            GetCasesForCloseReopenFromIncident();
        }
        
        /// <summary>
        ///  1. retrieve cases information from tbl_Incident
        ///  2. create case objects and insert them into case object list.
        /// </summary>
        private void GetCasesForCloseReopenFromIncident()
        {
            // the query is used to get case information from tbl_DTM_WorkspaceSyncStatus
            DatabaseAccessWrapper.StoredProcedure sp = new DatabaseAccessWrapper.StoredProcedure("[UDE].[get_close_reopen_cases_from_incident]", Environment.DBAutoProcessorConnectionString);
            
            DataTable caseIncident;
            if (!sp.ExecuteAndReturnTable(out caseIncident))
            {
                throw new CaseDBException("cannot retrieve cases information from tbl_Incident via sp: get_close_reopen_cases_from_incident");
            }
            else
            {
                builder.BuildCaseFromIncident(caseIncident);
            }
        }
        
    }
}
