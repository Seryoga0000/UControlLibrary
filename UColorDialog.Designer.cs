﻿namespace UControlLibrary
{
    partial class UColorDialog
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorsComboBox = new System.Windows.Forms.ComboBox();
            this.showColorDButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorsComboBox
            // 
            this.colorsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorsComboBox.FormattingEnabled = true;
            this.colorsComboBox.Location = new System.Drawing.Point(5, 5);
            this.colorsComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.colorsComboBox.Name = "colorsComboBox";
            this.colorsComboBox.Size = new System.Drawing.Size(347, 33);
            this.colorsComboBox.TabIndex = 0;
            this.colorsComboBox.TextChanged += new System.EventHandler(this.colorsComboBox_TextChanged);
            // 
            // showColorDButton
            // 
            this.showColorDButton.BackColor = System.Drawing.Color.Black;
            this.showColorDButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showColorDButton.Location = new System.Drawing.Point(0, 0);
            this.showColorDButton.Margin = new System.Windows.Forms.Padding(0);
            this.showColorDButton.Name = "showColorDButton";
            this.showColorDButton.Size = new System.Drawing.Size(54, 41);
            this.showColorDButton.TabIndex = 1;
            this.showColorDButton.UseVisualStyleBackColor = false;
            this.showColorDButton.Click += new System.EventHandler(this.showColorDButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.colorsComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.showColorDButton);
            this.splitContainer1.Size = new System.Drawing.Size(415, 41);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 2;
            // 
            // UColorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UColorDialog";
            this.Size = new System.Drawing.Size(415, 41);
            this.Load += new System.EventHandler(this.UColorDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox colorsComboBox;
        private System.Windows.Forms.Button showColorDButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
