namespace UsefulMethodsAndTools
{
    partial class DashboardForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageExcel = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainerExcel = new System.Windows.Forms.SplitContainer();
            this.dgWorkbook = new System.Windows.Forms.DataGrid();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPageExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExcel)).BeginInit();
            this.splitContainerExcel.Panel1.SuspendLayout();
            this.splitContainerExcel.Panel2.SuspendLayout();
            this.splitContainerExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkbook)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageExcel);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 516);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageExcel
            // 
            this.tabPageExcel.BackColor = System.Drawing.Color.LightGray;
            this.tabPageExcel.Controls.Add(this.splitContainerExcel);
            this.tabPageExcel.Location = new System.Drawing.Point(4, 23);
            this.tabPageExcel.Name = "tabPageExcel";
            this.tabPageExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExcel.Size = new System.Drawing.Size(862, 489);
            this.tabPageExcel.TabIndex = 0;
            this.tabPageExcel.Text = "Excel Import - Export";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(748, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(870, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(870, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainerExcel
            // 
            this.splitContainerExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerExcel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerExcel.Location = new System.Drawing.Point(3, 3);
            this.splitContainerExcel.Name = "splitContainerExcel";
            this.splitContainerExcel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerExcel.Panel1
            // 
            this.splitContainerExcel.Panel1.Controls.Add(this.dgWorkbook);
            // 
            // splitContainerExcel.Panel2
            // 
            this.splitContainerExcel.Panel2.Controls.Add(this.btnExport);
            this.splitContainerExcel.Panel2.Controls.Add(this.btnImport);
            this.splitContainerExcel.Size = new System.Drawing.Size(856, 483);
            this.splitContainerExcel.SplitterDistance = 401;
            this.splitContainerExcel.TabIndex = 0;
            // 
            // dgWorkbook
            // 
            this.dgWorkbook.DataMember = "";
            this.dgWorkbook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWorkbook.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgWorkbook.Location = new System.Drawing.Point(0, 0);
            this.dgWorkbook.Name = "dgWorkbook";
            this.dgWorkbook.Size = new System.Drawing.Size(856, 401);
            this.dgWorkbook.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Location = new System.Drawing.Point(22, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(151, 36);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(691, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(151, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 540);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPageExcel.ResumeLayout(false);
            this.splitContainerExcel.Panel1.ResumeLayout(false);
            this.splitContainerExcel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExcel)).EndInit();
            this.splitContainerExcel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageExcel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainerExcel;
        private System.Windows.Forms.DataGrid dgWorkbook;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
    }
}