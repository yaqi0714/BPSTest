using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class Utility
    {
        public static string BuildMessage(List<KeyValuePair<string, string>> info)
        {
            StringBuilder message = new StringBuilder();

            foreach (KeyValuePair<string, string> pair in info)
            {
                message.AppendLine(string.Format("{0}: {1}", pair.Key, pair.Value));
            }

            return message.ToString();
        }
    }
}
