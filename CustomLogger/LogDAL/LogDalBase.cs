using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CustomLogger.LogEntryType;

namespace CustomLogger.LogDAL
{
    abstract class LogDalBase
    {
        public abstract void Write(LogEntry log);
        public abstract DataSet ViewLog();
        public abstract DataSet ViewLog(string query);

    }
}
