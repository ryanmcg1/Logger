using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomLogger.LogEntryType
{
    public class LogEntry
    {
        public int LogEntryID { get; }
        public string LogEntrymessage { get; set; }
        public int LogEntrySeverity { get; set; }
        public string LogEntryError { get; set; }
        public string LogEntrySource { get; set; }
        public DateTime LogEntryDateCreated { get; set; }
    }
}
