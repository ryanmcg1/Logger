using CustomLogger.LogDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomLogger.LogEntryType;
using System.Data;
using CustomLogger.Validation;

namespace CustomLogger
{
    public class Logger
    {
        private LogDalBase _dal;

        #region Constructors
        public Logger()
        {
            //Defaults to sqlserver for now...
            _dal = new SqlServer();
        }

        public Logger(LogDatabaseTypes types)
        {
            //Choose the DAL type
            switch(types)
            {
                case LogDatabaseTypes.SqlServer:
                    _dal= new SqlServer();
                    break;
                case LogDatabaseTypes.WindowsEventLog:
                    _dal= new WindowsEventLog();
                    break;
                default:
                throw new Exception("LogDatabaseType Not Found");
            }
        }
        #endregion

        public void Write(LogEntry le)
        {
            _dal.Write(le);
        }

        public DataSet ViewLog()
        {
            return ViewLog("");
        }

        public DataSet ViewLog(string query)
        {
            DataSet ds = new DataSet();
            query = DataValidationHelper.GetString(query);
            ds = _dal.ViewLog(query);
            return ds;
        }
    }
}
