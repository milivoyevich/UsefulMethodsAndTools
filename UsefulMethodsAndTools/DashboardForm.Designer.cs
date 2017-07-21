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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpExcel = new System.Windows.Forms.TabPage();
            this.splitContainerExcel = new System.Windows.Forms.SplitContainer();
            this.dgWorkbook = new System.Windows.Forms.DataGrid();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.tpLanguage = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.btnExportLO = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rbOriginal = new System.Windows.Forms.RadioButton();
            this.rbLatin = new System.Windows.Forms.RadioButton();
            this.tcMain.SuspendLayout();
            this.tpExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExcel)).BeginInit();
            this.splitContainerExcel.Panel1.SuspendLayout();
            this.splitContainerExcel.Panel2.SuspendLayout();
            this.splitContainerExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkbook)).BeginInit();
            this.tpLanguage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpExcel);
            this.tcMain.Controls.Add(this.tpLanguage);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(891, 542);
            this.tcMain.TabIndex = 0;
            // 
            // tpExcel
            // 
            this.tpExcel.BackColor = System.Drawing.Color.LightGray;
            this.tpExcel.Controls.Add(this.splitContainerExcel);
            this.tpExcel.Location = new System.Drawing.Point(4, 23);
            this.tpExcel.Name = "tpExcel";
            this.tpExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tpExcel.Size = new System.Drawing.Size(883, 515);
            this.tpExcel.TabIndex = 0;
            this.tpExcel.Text = "Excel Import - Export";
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
            this.splitContainerExcel.Panel2.Controls.Add(this.btnExportLO);
            this.splitContainerExcel.Panel2.Controls.Add(this.btnExport);
            this.splitContainerExcel.Panel2.Controls.Add(this.btnImport);
            this.splitContainerExcel.Size = new System.Drawing.Size(877, 509);
            this.splitContainerExcel.SplitterDistance = 427;
            this.splitContainerExcel.TabIndex = 0;
            // 
            // dgWorkbook
            // 
            this.dgWorkbook.DataMember = "";
            this.dgWorkbook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWorkbook.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgWorkbook.Location = new System.Drawing.Point(0, 0);
            this.dgWorkbook.Name = "dgWorkbook";
            this.dgWorkbook.Size = new System.Drawing.Size(877, 427);
            this.dgWorkbook.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(712, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(151, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            // tpLanguage
            // 
            this.tpLanguage.Controls.Add(this.splitContainer1);
            this.tpLanguage.Location = new System.Drawing.Point(4, 23);
            this.tpLanguage.Name = "tpLanguage";
            this.tpLanguage.Padding = new System.Windows.Forms.Padding(3);
            this.tpLanguage.Size = new System.Drawing.Size(883, 515);
            this.tpLanguage.TabIndex = 1;
            this.tpLanguage.Text = "Language tools";
            this.tpLanguage.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(891, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnExportLO
            // 
            this.btnExportLO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportLO.Location = new System.Drawing.Point(555, 16);
            this.btnExportLO.Name = "btnExportLO";
            this.btnExportLO.Size = new System.Drawing.Size(151, 36);
            this.btnExportLO.TabIndex = 2;
            this.btnExportLO.Text = "Export LO";
            this.btnExportLO.UseVisualStyleBackColor = true;
            this.btnExportLO.Click += new System.EventHandler(this.btnExportLO_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer1.Panel2.Controls.Add(this.rbLatin);
            this.splitContainer1.Panel2.Controls.Add(this.rbOriginal);
            this.splitContainer1.Size = new System.Drawing.Size(877, 509);
            this.splitContainer1.SplitterDistance = 428;
            this.splitContainer1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(877, 196);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // rbOriginal
            // 
            this.rbOriginal.AutoSize = true;
            this.rbOriginal.Location = new System.Drawing.Point(29, 29);
            this.rbOriginal.Name = "rbOriginal";
            this.rbOriginal.Size = new System.Drawing.Size(109, 18);
            this.rbOriginal.TabIndex = 0;
            this.rbOriginal.TabStop = true;
            this.rbOriginal.Text = "Original (Cyrillic)";
            this.rbOriginal.UseVisualStyleBackColor = true;
            this.rbOriginal.CheckedChanged += new System.EventHandler(this.rbOriginal_CheckedChanged);
            // 
            // rbLatin
            // 
            this.rbLatin.AutoSize = true;
            this.rbLatin.Location = new System.Drawing.Point(167, 29);
            this.rbLatin.Name = "rbLatin";
            this.rbLatin.Size = new System.Drawing.Size(67, 18);
            this.rbLatin.TabIndex = 1;
            this.rbLatin.TabStop = true;
            this.rbLatin.Text = "to Latin";
            this.rbLatin.UseVisualStyleBackColor = true;
            this.rbLatin.CheckedChanged += new System.EventHandler(this.rbLatin_CheckedChanged);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 566);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcMain.ResumeLayout(false);
            this.tpExcel.ResumeLayout(false);
            this.splitContainerExcel.Panel1.ResumeLayout(false);
            this.splitContainerExcel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExcel)).EndInit();
            this.splitContainerExcel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkbook)).EndInit();
            this.tpLanguage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpExcel;
        private System.Windows.Forms.TabPage tpLanguage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainerExcel;
        private System.Windows.Forms.DataGrid dgWorkbook;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Button btnExportLO;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton rbLatin;
        private System.Windows.Forms.RadioButton rbOriginal;
    }
}