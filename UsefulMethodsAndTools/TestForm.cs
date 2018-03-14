using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryUMT;

namespace UsefulMethodsAndTools
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private DataSet ds = default(DataSet);

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void brnLoadExcel_Click(object sender, EventArgs e)
        {
            using(var ofd =new OpenFileDialog())
            {
                try
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        ds = ExcelImportExport.ImportExcelODBC(ofd.FileName);
                        dgImportExcel.DataSource = ds;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
