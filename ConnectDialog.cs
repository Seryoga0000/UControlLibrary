using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StenfordResearchDataCollector
{
    public partial class ConnectDialog : UserControl
    {
        public event EventHandler FindDeviceClick;
        public event EventHandler ConnectButtonClick;

        public ConnectDialog()
        {
            InitializeComponent();
        }

        public string SelectedDevice => deviceList.Text;

        public void SetDeviceList(List<string> dlist)
        {
            deviceList.Items.Clear();
            deviceList.Items.AddRange(dlist.ToArray());
            deviceList.DroppedDown = true;
        }
        public void SetDeviceList(string[] dlist)
        {
            deviceList.Items.Clear();
            deviceList.Items.AddRange(dlist);
            deviceList.DroppedDown = true;
        }
        protected virtual void OnFindDeviceClick()
        {
            FindDeviceClick?.Invoke(this, EventArgs.Empty);
        }
        private void findDevice_Click(object sender, EventArgs e)
        {
            OnFindDeviceClick();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            connectStatusLabel1.Text = "";
            connectStatusLabel2.Text = "";
            OnConnectButtonClick();
        }
        protected virtual void OnConnectButtonClick()
        {
            ConnectButtonClick?.Invoke(this, EventArgs.Empty);
        }

        public void SetConnectLabel1(string text)
        {
            connectStatusLabel1.Text = text;
        }
        public void SetConnectLabel2(string text)
        {
            connectStatusLabel2.Text = text;
        }
    }
}
