using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Close_Reopen_Workspaces
{
    class CaseBuilder
    {
        protected Context context;

        public CaseBuilder(Context _context)
        {
            this.context = _context;
        }

        public void BuildCaseFromIncident(DataTable table)
        {
            string caseNumber = string.Empty;
            string caseStatus = string.Empty;
            DateTime caseModifiedTime = DateTime.MinValue;

            foreach (DataRow row in table.Rows)
            {
                if (row["CaseNumber"] == null || string.IsNullOrEmpty((string)row["CaseNumber"]))
                {
                    EventLogger.WriteEventLog("the case number shouldn't be null or empty in tbl_incident");
                    continue;
                }
                else
                {
                    caseNumber = (string)row["CaseNumber"];
                }

                if (row["ModifiedTime"] == null || row["ModifiedTime"].ToString() == "")
                {
                    EventLogger.WriteEventLog(string.Format("case number:{0} ==== the case modified time shouldn't be null or empty in tbl_incident", caseNumber));
                    continue;
                }
                else
                {
                    caseModifiedTime = (DateTime)row["ModifiedTime"];
                }

                if (row["CaseStatus"] == null)
                {
                    EventLogger.WriteEventLog(string.Format("case number:{0} ==== the case status shouldn't be null or empty in tbl_incident", caseNumber));
                    continue;
                }
                else
                {
                    caseStatus = (string)row["CaseStatus"];
                }

                Case _case = new Case(context, caseNumber, caseModifiedTime, caseStatus);
                context.Cases.Add(_case);
                
            }
        }
    }
}
