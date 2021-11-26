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
    public partial class UProgressBar : UserControl
    {
        public UProgressBar()
        {
            InitializeComponent();
        }

        public Label ProgressLabel => progressLabel;

        public ProgressBar PBar => pBar;
        private void ProgressLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
