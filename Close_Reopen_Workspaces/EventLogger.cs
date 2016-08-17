using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Close_Reopen_Workspaces
{
    public class EventLogger
    {
        public static void WriteEventLog(String strEventText)
        {
            EventLogEntryType eEntryType = EventLogEntryType.Error;
            EventLog.WriteEntry(Environment.EventLogName, strEventText, eEntryType);
        }

        public static void WriteEventLog(String strEventText, Int32 iEventID)
        {
            EventLogEntryType eEntryType = EventLogEntryType.Error;
            EventLog.WriteEntry(Environment.EventLogName, strEventText, eEntryType, iEventID);
        }
    }
}
