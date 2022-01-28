namespace StenfordResearchDataCollector
{
    partial class ConnectDialog
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
            this.label11 = new System.Windows.Forms.Label();
            this.deviceList = new System.Windows.Forms.ComboBox();
            this.findDevice = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectStatusLabel1 = new System.Windows.Forms.Label();
            this.connectStatusLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Поиск средств измерений:";
            // 
            // deviceList
            // 
            this.deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceList.FormattingEnabled = true;
            this.deviceList.Location = new System.Drawing.Point(9, 37);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(427, 21);
            this.deviceList.TabIndex = 39;
            // 
            // findDevice
            // 
            this.findDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findDevice.Location = new System.Drawing.Point(329, 8);
            this.findDevice.Name = "findDevice";
            this.findDevice.Size = new System.Drawing.Size(107, 23);
            this.findDevice.TabIndex = 40;
            this.findDevice.Text = "Найти прибор";
            this.findDevice.UseVisualStyleBackColor = true;
            this.findDevice.Click += new System.EventHandler(this.findDevice_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(9, 64);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(107, 23);
            this.connectButton.TabIndex = 41;
            this.connectButton.Text = "Подключение";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // connectStatusLabel1
            // 
            this.connectStatusLabel1.AutoSize = true;
            this.connectStatusLabel1.Location = new System.Drawing.Point(15, 100);
            this.connectStatusLabel1.Name = "connectStatusLabel1";
            this.connectStatusLabel1.Size = new System.Drawing.Size(7, 13);
            this.connectStatusLabel1.TabIndex = 43;
            this.connectStatusLabel1.Text = "\r\n";
            // 
            // connectStatusLabel2
            // 
            this.connectStatusLabel2.AutoSize = true;
            this.connectStatusLabel2.Location = new System.Drawing.Point(15, 127);
            this.connectStatusLabel2.Name = "connectStatusLabel2";
            this.connectStatusLabel2.Size = new System.Drawing.Size(7, 13);
            this.connectStatusLabel2.TabIndex = 44;
            this.connectStatusLabel2.Text = "\r\n";
            // 
            // ConnectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectStatusLabel2);
            this.Controls.Add(this.connectStatusLabel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.findDevice);
            this.Controls.Add(this.connectButton);
            this.Name = "ConnectDialog";
            this.Size = new System.Drawing.Size(444, 154);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox deviceList;
        private System.Windows.Forms.Button findDevice;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label connectStatusLabel1;
        private System.Windows.Forms.Label connectStatusLabel2;
    }
}
