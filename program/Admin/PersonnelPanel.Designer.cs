namespace DemoRestaurant
{
    partial class PersonnelPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonnelPanel));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_addNewPersonnel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_editPersonnel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_updateTable = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(231, 47);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(557, 391);
            this.dgv.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_addNewPersonnel,
            this.toolStripButton_editPersonnel,
            this.toolStripButton_updateTable});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1078, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_addNewPersonnel
            // 
            this.toolStripButton_addNewPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_addNewPersonnel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addNewPersonnel.Image")));
            this.toolStripButton_addNewPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addNewPersonnel.Name = "toolStripButton_addNewPersonnel";
            this.toolStripButton_addNewPersonnel.Size = new System.Drawing.Size(151, 24);
            this.toolStripButton_addNewPersonnel.Text = "Добавить персонал";
            this.toolStripButton_addNewPersonnel.Click += new System.EventHandler(this.toolStripButton_addNewPersonnel_Click);
            // 
            // toolStripButton_editPersonnel
            // 
            this.toolStripButton_editPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_editPersonnel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_editPersonnel.Image")));
            this.toolStripButton_editPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_editPersonnel.Name = "toolStripButton_editPersonnel";
            this.toolStripButton_editPersonnel.Size = new System.Drawing.Size(139, 24);
            this.toolStripButton_editPersonnel.Text = "Изменить данные";
            this.toolStripButton_editPersonnel.Click += new System.EventHandler(this.toolStripButton_editPersonnel_Click);
            // 
            // toolStripButton_updateTable
            // 
            this.toolStripButton_updateTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_updateTable.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_updateTable.Image")));
            this.toolStripButton_updateTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_updateTable.Name = "toolStripButton_updateTable";
            this.toolStripButton_updateTable.Size = new System.Drawing.Size(82, 24);
            this.toolStripButton_updateTable.Text = "Обновить";
            this.toolStripButton_updateTable.Click += new System.EventHandler(this.toolStripButton_updateTable_Click);
            // 
            // PersonnelPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgv);
            this.Name = "PersonnelPanel";
            this.Text = "Personnel Panel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_addNewPersonnel;
        private System.Windows.Forms.ToolStripButton toolStripButton_editPersonnel;
        private System.Windows.Forms.ToolStripButton toolStripButton_updateTable;
    }
}