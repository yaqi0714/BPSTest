using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class Helper
    {
        protected void CloseWorkspacesByCaseNumber(string caseNumer)
        {
            UDEBaseService.UdeBaseServiceClient client = new UDEBaseService.UdeBaseServiceClient();
            client.CloseWorkspacesForCaseNumber(caseNumer, string.Empty);
        }

        protected void CloseWorkspacesByWorkspaceID(long workspaceID)
        {
            UDEBaseService.UdeBaseServiceClient client = new UDEBaseService.UdeBaseServiceClient();
            client.CloseWorkspaceWithId(workspaceID, string.Empty);
        }

        protected void CloseWorkspacesByWorkspaceID(string workspaceID)
        {
            long wsID = 0;
            try
            {
                wsID = long.Parse(workspaceID);
            }
            {
 
            }
            UDEBaseService.UdeBaseServiceClient client = new UDEBaseService.UdeBaseServiceClient();
            client.CloseWorkspaceWithId(workspaceID, string.Empty);
        }
    }
}
