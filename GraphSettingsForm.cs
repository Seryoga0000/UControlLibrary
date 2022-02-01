using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtensionLib;


namespace UControlLibrary
{
    internal partial class GraphSettingsForm : Form
    {
        private UDataChart ch;

        public GraphSettingsForm(UDataChart chart)
        {
            InitializeComponent();
            ch = chart;
            ActiveControl = MaxYComboBox;

        }

        private void GraphSettingsForm_Load(object sender, EventArgs e)
        {
            
        }

        #region Свойства
        public UColorDialog LineColorDialog => lineColorDialog;

        public ComboBox MinYComboBox => minYComboBox;

        public ComboBox MaxYComboBox => maxYComboBox;

        public ComboBox StepYComboBox => stepYComboBox;

        public ComboBox PointLimitComboBox => pointLimitComboBox;

        public Label YMaxLabel => yMaxLabel;

        public Label YMinLabel => yMinLabel;

        public Label YStepLabel => yStepLabel;

        public ComboBox AxisYDataFormat => axisYDataFormat;
        #endregion

        private void GraphSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else
            {
                //SaveSettings();
            }
            Hide();
        }

        //public int PointLimit
        //{
        //    get
        //    {
        //        int d = pointLimitComboBox.Text.ToInt(10);
        //        pointLimitComboBox.Text = d.ToString(CultureInfo.InvariantCulture);
        //        return d;
        //    }
        //}

        //public double YMax
        //{
        //    get
        //    {
        //        double d = maxYComboBox.Text.ToDouble();
        //        maxYComboBox.Text = d.ToString(CultureInfo.InvariantCulture);
        //        return d;
        //    }
        //}

        //public double YMin
        //{
        //    get
        //    {
        //        double d = minYComboBox.Text.ToDouble();
        //        minYComboBox.Text = d.ToString(CultureInfo.InvariantCulture);
        //        return d;
        //    }
        //}

        //public double YStep
        //{
        //    get
        //    {
        //        double d = stepYComboBox.Text.ToDouble();
        //        stepYComboBox.Text = d.ToString(CultureInfo.InvariantCulture);
        //        return d;
        //    }
        //}

        private void yMaxLabel_Click(object sender, EventArgs e)
        {
        }

        private void yMinLabel_Click(object sender, EventArgs e)
        {
           
        }

        private void yStepLabel_Click(object sender, EventArgs e)
        {
            //StepYComboBox.Text = ch.ChartAreas[0].AxisY.Interval.ToString();
        }

        private void yMaxLabel_DoubleClick(object sender, EventArgs e)
        {
            ActiveControl = MaxYComboBox;
            MaxYComboBox.Text = ch.ChartAreas[0].AxisY.ScaleView.ViewMaximum.ToString();
        }

        private void yMinLabel_DoubleClick(object sender, EventArgs e)
        {
            ActiveControl = MinYComboBox;
            MinYComboBox.Text = ch.ChartAreas[0].AxisY.ScaleView.ViewMinimum.ToString();
        }

        private void yStepLabel_DoubleClick(object sender, EventArgs e)
        {

        }

        private void maxYComboBox_TextChanged(object sender, EventArgs e)
        {
            //var s = sender as ComboBox;
            //if (s == null) return;
            //s.Text = s.Text.Replace(",", ".");
        }

        private void LineColorDialog_Load(object sender, EventArgs e)
        {
            LineColorDialog.Width = 350;
        }

        private void applySettings_Click(object sender, EventArgs e)
        {
            ch.LabelYFormat = AxisYDataFormat.Text;

        }
    }
}
