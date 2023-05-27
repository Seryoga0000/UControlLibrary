using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UControlLibrary
{
    public partial class MessageToolStripStatusLabel : ToolStripStatusLabel
    {
        
        public MessageToolStripStatusLabel()
        {
            InitializeComponent();

        }

        public void ShortTimeMessage(string text, int timeInterval)
        {
            Text = text;
            new OneTimer(() => Text = "", timeInterval).Start();
        }
    }
}
