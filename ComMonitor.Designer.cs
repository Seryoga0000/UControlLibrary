namespace UControlLibrary
{
    partial class ComMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.monitorTable = new System.Windows.Forms.DataGridView();
            this.UDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.monitorTable)).BeginInit();
            this.SuspendLayout();
            // 
            // monitorTable
            // 
            this.monitorTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.monitorTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monitorTable.ColumnHeadersVisible = false;
            this.monitorTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UDateTime,
            this.Column1});
            this.monitorTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitorTable.Location = new System.Drawing.Point(0, 0);
            this.monitorTable.Name = "monitorTable";
            this.monitorTable.RowHeadersVisible = false;
            this.monitorTable.Size = new System.Drawing.Size(457, 366);
            this.monitorTable.TabIndex = 35;
            this.monitorTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.monitorTable_CellContentClick);
            // 
            // UDateTime
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UDateTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.UDateTime.HeaderText = "Column2";
            this.UDateTime.Name = "UDateTime";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // ComMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monitorTable);
            this.Name = "ComMonitor";
            this.Size = new System.Drawing.Size(457, 366);
            ((System.ComponentModel.ISupportInitialize)(this.monitorTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView monitorTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn UDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
