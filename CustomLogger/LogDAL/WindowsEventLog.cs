using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CustomLogger.LogDAL;
using CustomLogger.LogEntryType;

namespace CustomLogger.LogDAL
{
    class WindowsEventLog : LogDalBase
    {
        public override DataSet ViewLog()
        {
            throw new NotImplementedException();
        }

        public override DataSet ViewLog(string query)
        {
            throw new NotImplementedException();
        }

        public override void Write(LogEntry log)
        {
            throw new NotImplementedException();
        }
    }
}
