using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibraryUMT.Metode
{
    public static class ExtMetode
    {
        private static long brojac;
        private static int lokX, lokY;
        public static void dragMe(this Control kontrola, MouseEventArgs e)
        {
            if(brojac++ %2==0 && e.Button == MouseButtons.Left)
            {
                kontrola.Location = new Point(kontrola.Location.X + e.X - lokX, kontrola.Location.Y + e.Y - lokY);
                Cursor.Current = Cursors.SizeAll;
                kontrola.BringToFront();
            }
            lokX = e.X;
            lokY = e.Y;
           
        }

        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {      
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static DataSet ParseExcel(string fileName)
        {
            string connectionString = string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=Excel 8.0;", fileName);


            DataSet data = new DataSet();

            foreach (var sheetName in GetExcelSheetNames(connectionString))
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    var dataTable = new DataTable();
                    string query = string.Format("SELECT * FROM [{0}]", sheetName);
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    data.Tables.Add(dataTable);
                }
            }

            return data;
        }

        static string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                return null;
            }

            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            return excelSheetNames;
        }    
    }
}
