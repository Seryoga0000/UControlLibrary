namespace UControlLibrary
{
    partial class GraphSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.yStepLabel = new System.Windows.Forms.Label();
            this.yMinLabel = new System.Windows.Forms.Label();
            this.yMaxLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.axisYDataFormat = new System.Windows.Forms.ComboBox();
            this.stepYComboBox = new System.Windows.Forms.ComboBox();
            this.minYComboBox = new System.Windows.Forms.ComboBox();
            this.maxYComboBox = new System.Windows.Forms.ComboBox();
            this.pointLimitComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lineColorDialog = new UControlLibrary.UColorDialog();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(43, 349);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.label3.MaximumSize = new System.Drawing.Size(400, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Формат отображения меток по оси Y";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yStepLabel
            // 
            this.yStepLabel.AutoSize = true;
            this.yStepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yStepLabel.Location = new System.Drawing.Point(43, 298);
            this.yStepLabel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.yStepLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.yStepLabel.Name = "yStepLabel";
            this.yStepLabel.Size = new System.Drawing.Size(128, 25);
            this.yStepLabel.TabIndex = 8;
            this.yStepLabel.Text = "Шаг по оси Y";
            this.yStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yStepLabel.Click += new System.EventHandler(this.yStepLabel_Click);
            this.yStepLabel.DoubleClick += new System.EventHandler(this.yStepLabel_DoubleClick);
            // 
            // yMinLabel
            // 
            this.yMinLabel.AutoSize = true;
            this.yMinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yMinLabel.Location = new System.Drawing.Point(43, 247);
            this.yMinLabel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.yMinLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.yMinLabel.Name = "yMinLabel";
            this.yMinLabel.Size = new System.Drawing.Size(310, 25);
            this.yMinLabel.TabIndex = 7;
            this.yMinLabel.Text = "Минимальное     значение оси Y";
            this.yMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yMinLabel.Click += new System.EventHandler(this.yMinLabel_Click);
            this.yMinLabel.DoubleClick += new System.EventHandler(this.yMinLabel_DoubleClick);
            // 
            // yMaxLabel
            // 
            this.yMaxLabel.AutoSize = true;
            this.yMaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yMaxLabel.Location = new System.Drawing.Point(43, 188);
            this.yMaxLabel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.yMaxLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.yMaxLabel.Name = "yMaxLabel";
            this.yMaxLabel.Size = new System.Drawing.Size(298, 25);
            this.yMaxLabel.TabIndex = 6;
            this.yMaxLabel.Text = "Максимальное значение оси Y";
            this.yMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yMaxLabel.Click += new System.EventHandler(this.yMaxLabel_Click);
            this.yMaxLabel.DoubleClick += new System.EventHandler(this.yMaxLabel_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(43, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.label2.MaximumSize = new System.Drawing.Size(400, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Максимальное количество точек";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // axisYDataFormat
            // 
            this.axisYDataFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axisYDataFormat.FormattingEnabled = true;
            this.axisYDataFormat.Items.AddRange(new object[] {
            "0.##",
            "0.##E+00",
            "0.####",
            "0.####E+00",
            "0.######",
            "0.######E+00"});
            this.axisYDataFormat.Location = new System.Drawing.Point(478, 349);
            this.axisYDataFormat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.axisYDataFormat.Name = "axisYDataFormat";
            this.axisYDataFormat.Size = new System.Drawing.Size(160, 33);
            this.axisYDataFormat.TabIndex = 13;
            this.axisYDataFormat.Text = "0.##E+00";
            // 
            // stepYComboBox
            // 
            this.stepYComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepYComboBox.FormattingEnabled = true;
            this.stepYComboBox.Items.AddRange(new object[] {
            "NaN"});
            this.stepYComboBox.Location = new System.Drawing.Point(478, 298);
            this.stepYComboBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.stepYComboBox.Name = "stepYComboBox";
            this.stepYComboBox.Size = new System.Drawing.Size(113, 33);
            this.stepYComboBox.TabIndex = 11;
            this.stepYComboBox.Text = "NaN";
            // 
            // minYComboBox
            // 
            this.minYComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minYComboBox.FormattingEnabled = true;
            this.minYComboBox.Items.AddRange(new object[] {
            "NaN"});
            this.minYComboBox.Location = new System.Drawing.Point(478, 244);
            this.minYComboBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.minYComboBox.Name = "minYComboBox";
            this.minYComboBox.Size = new System.Drawing.Size(113, 33);
            this.minYComboBox.TabIndex = 10;
            this.minYComboBox.Text = "NaN";
            // 
            // maxYComboBox
            // 
            this.maxYComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxYComboBox.FormattingEnabled = true;
            this.maxYComboBox.Items.AddRange(new object[] {
            "NaN"});
            this.maxYComboBox.Location = new System.Drawing.Point(478, 188);
            this.maxYComboBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.maxYComboBox.Name = "maxYComboBox";
            this.maxYComboBox.Size = new System.Drawing.Size(113, 33);
            this.maxYComboBox.TabIndex = 9;
            this.maxYComboBox.Text = "NaN";
            this.maxYComboBox.TextChanged += new System.EventHandler(this.maxYComboBox_TextChanged);
            // 
            // pointLimitComboBox
            // 
            this.pointLimitComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointLimitComboBox.FormattingEnabled = true;
            this.pointLimitComboBox.Items.AddRange(new object[] {
            "1000",
            "10000",
            "20000",
            "50000",
            "100000",
            "200000",
            "500000"});
            this.pointLimitComboBox.Location = new System.Drawing.Point(478, 127);
            this.pointLimitComboBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pointLimitComboBox.Name = "pointLimitComboBox";
            this.pointLimitComboBox.Size = new System.Drawing.Size(113, 33);
            this.pointLimitComboBox.TabIndex = 5;
            this.pointLimitComboBox.Text = "10000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.label1.MaximumSize = new System.Drawing.Size(400, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Цвет линии графика";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineColorDialog
            // 
            this.lineColorDialog.Location = new System.Drawing.Point(478, 42);
            this.lineColorDialog.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.lineColorDialog.Name = "lineColorDialog";
            this.lineColorDialog.SelectedColor = System.Drawing.Color.Black;
            this.lineColorDialog.Size = new System.Drawing.Size(253, 45);
            this.lineColorDialog.TabIndex = 3;
            this.lineColorDialog.Load += new System.EventHandler(this.LineColorDialog_Load);
            // 
            // GraphSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 300);
            this.ClientSize = new System.Drawing.Size(826, 480);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.axisYDataFormat);
            this.Controls.Add(this.yStepLabel);
            this.Controls.Add(this.yMinLabel);
            this.Controls.Add(this.lineColorDialog);
            this.Controls.Add(this.yMaxLabel);
            this.Controls.Add(this.stepYComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pointLimitComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minYComboBox);
            this.Controls.Add(this.maxYComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "GraphSettingsForm";
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphSettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.GraphSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UColorDialog lineColorDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pointLimitComboBox;
        private System.Windows.Forms.Label yMaxLabel;
        private System.Windows.Forms.Label yMinLabel;
        private System.Windows.Forms.ComboBox stepYComboBox;
        private System.Windows.Forms.ComboBox minYComboBox;
        private System.Windows.Forms.ComboBox maxYComboBox;
        private System.Windows.Forms.Label yStepLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox axisYDataFormat;
        private System.Windows.Forms.Label label1;
    }
}