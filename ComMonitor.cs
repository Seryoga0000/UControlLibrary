using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UControlLibrary
{
    public partial class ComMonitor: UserControl
    {
        public bool IgnoreEmpry { get; set; } = true;

        public ComMonitor()
        {
            InitializeComponent();
        }

        public DataGridView MonitorTable => monitorTable;
        public void MonitorAdd(string mes)
        {
            if (IgnoreEmpry && string.IsNullOrEmpty(mes)) return;
           
            int i = monitorTable.Rows.Add();
            monitorTable[0, i].Value = DateTime.Now.ToLongTimeString();
            monitorTable[1, i].Value = mes;
            monitorTable.CurrentCell = monitorTable[1, i];
        }

        private void monitorTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
