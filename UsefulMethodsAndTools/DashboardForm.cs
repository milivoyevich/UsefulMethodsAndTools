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
                        DataSetHelper.CreateWorkbook(sd.FileName, ds);
                    }
                    
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
