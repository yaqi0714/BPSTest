using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class Case
    {
        public string CaseNumber { get; set; }

        public DateTime CaseModifiedTime { get; set; }

        public Common.CaseStatus Status { get; set; }

        protected Context context;

        static UDEBaseService.WorkspaceInternalUser internalUser;

        static Case()
        {
            internalUser = new UDEBaseService.WorkspaceInternalUser();
            internalUser.UserName = Environment.UserName;
            internalUser.DomainName = Environment.DomainName;
            internalUser.Location = new UDEBaseService.Location();
            internalUser.Location.Region = UDEBaseService.Region.US;
            internalUser.Location.CountryCode = "USA";
            internalUser.Role = UDEBaseService.WorkspaceUserRole.WORKSPACEADMIN;
        }

        public Case(Context _context, string _caseNumber, DateTime _caseModifiedTime, string _Status)
        {
            this.context = _context;
            this.CaseNumber = _caseNumber;
            this.CaseModifiedTime = _caseModifiedTime;
            this.Status = Common.CaseStatus.Open;
            Common.CaseStatus cs;
            if (Enum.TryParse(_Status, true, out cs))
            {
                this.Status = cs;
            }
        }

        protected void CloseWorkspaces()
        {
            UDEBaseService.UdeBaseServiceClient client = new UDEBaseService.UdeBaseServiceClient();
            client.CloseWorkspacesForCaseNumber(this.CaseNumber, string.Empty);
        }

        

        protected void ReopenWorkspaces()
        {
            UDEBaseService.UdeBaseServiceClient client = new UDEBaseService.UdeBaseServiceClient();
            List<UDEBaseService.WorkspaceBaseUser> users = new List<UDEBaseService.WorkspaceBaseUser>();
            users.Add(internalUser);
            client.ReOpenWorkspacesForCaseNumber(this.CaseNumber, users.ToArray(), string.Empty);
        }

        public void ProcessWorkspaces()
        {
            bool success = true;

            try
            {
                if (Status == Common.CaseStatus.Closed)
                {
                    CloseWorkspaces();
                }
                else if (Status == Common.CaseStatus.Open)
                {
                    ReopenWorkspaces();
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("cannot {0} workspaces for case: {1}", Status, CaseNumber));
                sb.AppendLine(ex.Message);
                EventLogger.WriteEventLog(sb.ToString());
                success = false;
            }

            // call [UDE].[update_status_after_close_reopen_workspaces_for_case]
            // to update success or failure status after closing or reopening workspaces for case.
            DatabaseAccessWrapper.StoredProcedure sp = new DatabaseAccessWrapper.StoredProcedure("[UDE].[update_status_after_close_reopen_workspaces_for_case]", Environment.DBAutoProcessorConnectionString);
            sp.AddCommandParameter("@CaseNumber", CaseNumber, 50);
            sp.AddCommandParameter("@CaseStatus", Status.ToString(), 16);
            sp.AddCommandParameter("@Success", success);
            if (!sp.ExecuteNoReturn())
            {
                throw new SPDBException("cannot run the [UDE].[update_status_after_close_reopen_workspaces_for_case] stored procedure");
            }
        }
    }
}
