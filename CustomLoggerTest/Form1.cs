using CustomLogger.LogEntryType;
using System;
using CustomLogger;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomLogger.LogDAL;

namespace CustomLoggerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customLoggerDataSet.LogFile' table. You can move, or remove it, as needed.
            this.logFileTableAdapter.Fill(this.customLoggerDataSet.LogFile);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            LogEntry le = new LogEntry();
            le.LogEntrySeverity = 7;
            le.LogEntrymessage = "test";
            le.LogEntryDateCreated = DateTime.Now;
            le.LogEntryError = "a";
            le.LogEntrySource = "source";


            Logger CL = new Logger(LogDatabaseTypes.SqlServer);
            CL.Write(le);

            this.logFileTableAdapter.Fill(this.customLoggerDataSet.LogFile);
        }

        private void logFileBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.logFileBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.customLoggerDataSet);

        }

        private void logFileDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
