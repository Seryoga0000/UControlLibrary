using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UControlLibrary
{
    internal partial class UColorDialog : UserControl
    {
        private ColorDialog colorDialog;

        private Color selectedColor = Color.Black;

        public Color SelectedColor
        {
            get => selectedColor;
            set
            {
                selectedColor = value;
                colorsComboBox.Text = selectedColor.ToString();
                OnColorChanged();
            }
        }

        public event EventHandler ColorChanged;

        public UColorDialog()
        {
            InitializeComponent();
            colorDialog = new ColorDialog();
            
            colorsComboBox.Items.Add(Color.Black.ToString());
            colorsComboBox.Items.Add(Color.White.ToString());
            colorsComboBox.Items.Add(Color.Blue.ToString());
            colorsComboBox.Items.Add(Color.Maroon.ToString());
            colorsComboBox.Items.Add(Color.DarkGreen.ToString());
            colorsComboBox.Items.Add(Color.Orange.ToString());
            colorsComboBox.Items.Add(Color.BlueViolet.ToString());
            colorsComboBox.Text = Color.Black.ToString();
        }

        private void UColorDialog_Load(object sender, EventArgs e)
        {
         
        }

        private void showColorDButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog()==DialogResult.Cancel) return;
            selectedColor = colorDialog.Color;
            colorsComboBox.Text = SelectedColor.ToString();
            OnColorChanged();
        }

        protected virtual void OnColorChanged()
        {
            showColorDButton.BackColor = SelectedColor;
            ColorChanged?.Invoke(this, EventArgs.Empty);
        }

        private void colorsComboBox_TextChanged(object sender, EventArgs e)
        {
            ComboBox s = (ComboBox)sender;
            if (s == null) return;
            string str = Regex.Match(s.Text, @"\[.+?\]").Value.TrimStart('[').TrimEnd(']');

            selectedColor = Color.FromName(str);
            OnColorChanged();
        }
    }
}
