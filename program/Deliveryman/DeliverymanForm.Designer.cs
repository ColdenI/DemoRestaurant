namespace DemoRestaurant
{
    partial class DeliverymanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliverymanForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_setStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_UpdateTable = new System.Windows.Forms.ToolStripButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripButton_setStatus,
            this.toolStripButton_UpdateTable});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_setStatus
            // 
            this.toolStripButton_setStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_setStatus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_setStatus.Image")));
            this.toolStripButton_setStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_setStatus.Name = "toolStripButton_setStatus";
            this.toolStripButton_setStatus.Size = new System.Drawing.Size(86, 28);
            this.toolStripButton_setStatus.Text = "Доставлен";
            this.toolStripButton_setStatus.Click += new System.EventHandler(this.toolStripButton_setStatus_Click);
            // 
            // toolStripButton_UpdateTable
            // 
            this.toolStripButton_UpdateTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_UpdateTable.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_UpdateTable.Image")));
            this.toolStripButton_UpdateTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_UpdateTable.Name = "toolStripButton_UpdateTable";
            this.toolStripButton_UpdateTable.Size = new System.Drawing.Size(82, 28);
            this.toolStripButton_UpdateTable.Text = "Обновить";
            this.toolStripButton_UpdateTable.Click += new System.EventHandler(this.toolStripButton_UpdateTable_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(319, 221);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(240, 150);
            this.dgv.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(126, 28);
            this.toolStripLabel1.Text = "Изменить статус:";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 28);
            this.toolStripButton1.Text = "В пути";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // DeliverymanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DeliverymanForm";
            this.Text = "DeliverymanForm";
            this.Load += new System.EventHandler(this.DeliverymanForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripButton toolStripButton_setStatus;
        private System.Windows.Forms.ToolStripButton toolStripButton_UpdateTable;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}