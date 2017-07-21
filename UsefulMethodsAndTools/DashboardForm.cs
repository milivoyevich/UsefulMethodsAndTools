using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassLibraryUMT;
using ExcelLibrary;

namespace UsefulMethodsAndTools
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var ds = default(DataSet);
            dgWorkbook.DataSource = ds;
            try
            {
                if (ofdExcel.ShowDialog() == DialogResult.OK)
                {
                    switch (ofdExcel.SafeFileName.Substring(ofdExcel.SafeFileName.IndexOf(".") + 1).ToLower())
                    {
                        case "xls":  ds = DataSetHelper.CreateDataSet(ofdExcel.FileName); break;
                        case "xlsx": ds = ExcelImportExport.ImportExcelODBC(ofdExcel.FileName); break;
                        default:
                            Stream ss = File.OpenRead(ofdExcel.FileName);
                            ds = ExcelImportExport.ImportExcelXML(ss, true, false); break;
                    }
                    foreach (DataTable tabela in ds.Tables)
                    {
                        foreach (DataRow red in tabela.Rows)
                        {
                            string sred = string.Empty;
                            foreach (object polje in red.ItemArray)
                            {
                                sred = sred + polje.ToString().Trim();                                
                            }
                            foreach(DataColumn kolona in tabela.Columns)
                            {
                                if (red[kolona].ToString() == string.Empty)
                                {
                                    switch (kolona.DataType.Name)
                                    {
                                        case "String":  red[kolona] = ""; break;
                                        case "DateTime": red[kolona] = DateTime.Today; break;
                                        case "Boolean": red[kolona] = false; break;
                                        default: red[kolona] = 0; break;
                                    }
                                    
                                }
                            }
                            if (sred.Trim() == string.Empty) red.Delete();
                        }
                    }
                    ds.AcceptChanges();
                    dgWorkbook.DataSource = ds;
                    ofdExcel.Dispose();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sd = new SaveFileDialog())
                {
                    var ds = (DataSet)dgWorkbook.DataSource;
                    sd.FileName = ds.DataSetName;
                    sd.Filter = "Excel files|*.xls";
                    if(sd.ShowDialog()==DialogResult.OK)
                    {
                        ds.AcceptChanges();
                        DataSetHelper.CreateWorkbook(sd.FileName, ds);
                    }
                    
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnExportLO_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sd = new SaveFileDialog())
                {
                    var ds = (DataSet)dgWorkbook.DataSource;
                    sd.FileName = ds.DataSetName;
                    sd.Filter = "Excel files|*.xls";
                    if (sd.ShowDialog() == DialogResult.OK)
                    {                    
                        ExcelImportExport.exportExcelLO(sd.FileName, ds);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string orignalText=string.Empty;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (rbOriginal.Checked)
            {
                orignalText = richTextBox1.Text;
            }
        }

        private void rbOriginal_CheckedChanged(object sender, EventArgs e)
        {
            if(rbOriginal.Checked)
            {
                richTextBox1.Text = orignalText;
            }
        }

        private void rbLatin_CheckedChanged(object sender, EventArgs e)
        {
            if(rbLatin.Checked)
            {
               richTextBox1.Text= ClassUMT.CyrlToLatn(orignalText);
                string ppp = string.Empty;
                
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var ds = new DataSet();
                    ds.ReadXml(ofd.FileName);
                    rtbPoco.Text = ClassUMT.DtoToPoco(ds);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
