using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CustomLogger.LogEntryType;
using System.Data;

namespace CustomLogger.LogDAL
{
    class SqlServer : LogDalBase
    {
        private string tableName ="LogFile";
        private string sqlConnString { get; set; }

        public SqlServer()
        {
            sqlConnString = "Persist Security Info=False;database=CustomLogger;server=localhost\\sqlexpress;user id=rmcguckin;password=***;Current Language=English;Connection Timeout=60;";
        }

        public override void Write(LogEntry logEvent)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(sqlConnString))
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO " + tableName + " values (@LogEntrymessage,@LogEntrySeverity,@LogEntryError,@LogEntrySource,@LogEntryDateCreated)", sqlConn))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@LogEntrymessage", logEvent.LogEntrymessage));
                        sqlCommand.Parameters.Add(new SqlParameter("@LogEntrySeverity", logEvent.LogEntrySeverity));
                        sqlCommand.Parameters.Add(new SqlParameter("@LogEntryError", logEvent.LogEntryError));
                        sqlCommand.Parameters.Add(new SqlParameter("@LogEntrySource", logEvent.LogEntrySource));
                        sqlCommand.Parameters.Add(new SqlParameter("@LogEntryDateCreated", logEvent.LogEntryDateCreated));
                        sqlConn.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConn.Close(); 
                    }
            }
            catch (SqlException ex )
            {
                throw ex ;
            }
        }


        public override DataSet ViewLog()
        {
            return ViewLog(string.Empty);
        }

        public override DataSet ViewLog(string where)
        {
            if(where != string.Empty)
            {
                where = string.Format("SELECT * from {0} WHERE {1}", tableName, where);
            }
            else
            {
                where = string.Format("SELECT * from {0}", tableName);
            }
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(sqlConnString))
                using (SqlDataAdapter sqlDA = new SqlDataAdapter(where, sqlConn))
                {
                    DataSet ds = new DataSet();
                    sqlConn.Open();
                    sqlDA.Fill(ds);
                    sqlConn.Close();
                    return ds;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
