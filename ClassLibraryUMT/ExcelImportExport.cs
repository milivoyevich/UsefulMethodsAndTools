using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Reflection;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.sheet;
using unoidl.com.sun.star.container;
using unoidl.com.sun.star.table;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.accessibility;
using System.Text.RegularExpressions;

namespace ClassLibraryUMT
{
    public static class ExcelImportExport
    {
        #region import
        public static DataSet ImportExcelODBC(string FileName)
        {
            DataSet output = new DataSet("dsODBC");
            try
            {
                string strConn = "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)}; DriverId=790; DBQ=" + FileName + ";";
                using (OdbcConnection conn = new OdbcConnection(strConn))
                {
                    conn.Open();
                    DataTable dt = conn.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string sheet = row["TABLE_NAME"].ToString();

                        var cmd = new OdbcCommand("SELECT * FROM [" + sheet + "]", conn);
                        cmd.CommandType = CommandType.Text;

                        DataTable outputTable = new DataTable(sheet);
                        output.Tables.Add(outputTable);
                        new OdbcDataAdapter(cmd).Fill(outputTable);
                    }

                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return output;
        }

        public static DataSet ImportExcelXML(Stream inputFileStream, bool hasHeaders, bool autoDetectColumnType)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new XmlTextReader(inputFileStream));
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);

            nsmgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
            nsmgr.AddNamespace("x", "urn:schemas-microsoft-com:office:excel");
            nsmgr.AddNamespace("ss", "urn:schemas-microsoft-com:office:spreadsheet");

            DataSet ds = new DataSet();

            foreach (XmlNode node in doc.DocumentElement.SelectNodes("//ss:Worksheet", nsmgr))
            {
                DataTable dt = new DataTable(node.Attributes["ss:Name"].Value);
                ds.Tables.Add(dt);
                XmlNodeList rows = node.SelectNodes("ss:Table/ss:Row", nsmgr);
                if (rows.Count > 0)
                {
                    List<ColumnType> columns = new List<ColumnType>();
                    int startIndex = 0;
                    if (hasHeaders)
                    {
                        foreach (XmlNode data in rows[0].SelectNodes("ss:Cell/ss:Data", nsmgr))
                        {
                            columns.Add(new ColumnType(typeof(string)));//default to text
                            dt.Columns.Add(data.InnerText, typeof(string));
                        }
                        startIndex++;
                    }
                    if (autoDetectColumnType && rows.Count > 0)
                    {
                        XmlNodeList cells = rows[startIndex].SelectNodes("ss:Cell", nsmgr);
                        int actualCellIndex = 0;
                        for (int cellIndex = 0; cellIndex < cells.Count; cellIndex++)
                        {
                            XmlNode cell = cells[cellIndex];
                            if (cell.Attributes["ss:Index"] != null)
                                actualCellIndex = int.Parse(cell.Attributes["ss:Index"].Value) - 1;

                            ColumnType autoDetectType = getType(cell.SelectSingleNode("ss:Data", nsmgr));

                            if (actualCellIndex >= dt.Columns.Count)
                            {
                                dt.Columns.Add("Column" + actualCellIndex.ToString(), autoDetectType.type);
                                columns.Add(autoDetectType);
                            }
                            else
                            {
                                dt.Columns[actualCellIndex].DataType = autoDetectType.type;
                                columns[actualCellIndex] = autoDetectType;
                            }

                            actualCellIndex++;
                        }
                    }
                    for (int i = startIndex; i < rows.Count; i++)
                    {
                        DataRow row = dt.NewRow();
                        XmlNodeList cells = rows[i].SelectNodes("ss:Cell", nsmgr);
                        int actualCellIndex = 0;
                        for (int cellIndex = 0; cellIndex < cells.Count; cellIndex++)
                        {
                            XmlNode cell = cells[cellIndex];
                            if (cell.Attributes["ss:Index"] != null)
                                actualCellIndex = int.Parse(cell.Attributes["ss:Index"].Value) - 1;

                            XmlNode data = cell.SelectSingleNode("ss:Data", nsmgr);

                            if (actualCellIndex >= dt.Columns.Count)
                            {
                                for (int ii = dt.Columns.Count; ii < actualCellIndex; ii++)
                                {
                                    dt.Columns.Add("Column" + actualCellIndex.ToString(), typeof(string));
                                    columns.Add(getDefaultType());
                                }
                                ColumnType autoDetectType = getType(cell.SelectSingleNode("ss:Data", nsmgr));
                                dt.Columns.Add("Column" + actualCellIndex.ToString(), typeof(string));
                                columns.Add(autoDetectType);
                            }
                            if (data != null)
                                row[actualCellIndex] = data.InnerText;

                            actualCellIndex++;
                        }

                        dt.Rows.Add(row);
                    }
                }
            }
            return ds;

            //<?xml version="1.0"?>
            //<?mso-application progid="Excel.Sheet"?>
            //<Workbook>
            // <Worksheet ss:Name="Sheet1">
            //  <Table>
            //   <Row>
            //    <Cell><Data ss:Type="String">Item Number</Data></Cell>
            //    <Cell><Data ss:Type="String">Description</Data></Cell>
            //    <Cell ss:StyleID="s21"><Data ss:Type="String">Item Barcode</Data></Cell>
            //   </Row>
            // </Worksheet>
            //</Workbook>
        }

        private static ColumnType getDefaultType()
        {
            return new ColumnType(typeof(String));
        }

        private static ColumnType getType(XmlNode data)
        {
            string type = null;
            if (data.Attributes["ss:Type"] == null || data.Attributes["ss:Type"].Value == null)
                type = "";
            else
                type = data.Attributes["ss:Type"].Value;

            switch (type)
            {
                case "DateTime":
                    return new ColumnType(typeof(DateTime));
                case "Boolean":
                    return new ColumnType(typeof(Boolean));
                case "Number":
                    return new ColumnType(typeof(Decimal));
                case "":
                    decimal test2;
                    if (data == null || String.IsNullOrEmpty(data.InnerText) || decimal.TryParse(data.InnerText, out test2))
                    {
                        return new ColumnType(typeof(Decimal));
                    }
                    else
                    {
                        return new ColumnType(typeof(String));
                    }
                default://"String"
                    return new ColumnType(typeof(String));
            }
        }

        struct ColumnType
        {
            public Type type;
            private string name;
            public ColumnType(Type type) { this.type = type; this.name = type.ToString().ToLower(); }
            public object ParseString(string input)
            {
                if (String.IsNullOrEmpty(input))
                    return DBNull.Value;
                switch (type.ToString())
                {
                    case "system.datetime":
                        return DateTime.Parse(input);
                    case "system.decimal":
                        return decimal.Parse(input);
                    case "system.boolean":
                        return bool.Parse(input);
                    default:
                        return input;
                }
            }
        }
        #endregion
        #region export
       public static void exportExcelLO(string FileName, DataSet ds)
        {
            try
            {

                string unoPath = @"C:\Program Files (x86)\LibreOffice 5\program";
                Environment.SetEnvironmentVariable("UNO_PATH", unoPath, EnvironmentVariableTarget.Process);
                Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + @";"
                                                   + unoPath, EnvironmentVariableTarget.Process);

                XComponentContext oStrap = uno.util.Bootstrap.bootstrap();
                XMultiServiceFactory oServMan = (XMultiServiceFactory)oStrap.getServiceManager();
                XComponentLoader desktop = (XComponentLoader)oServMan.createInstance("com.sun.star.frame.Desktop");
                string url = @"private:factory/scalc";
                PropertyValue[] loadProps = new PropertyValue[3];
                loadProps[0] = new PropertyValue();
                loadProps[0].Name = "Hidden";
                loadProps[0].Value = new uno.Any(true);
                loadProps[1] = new PropertyValue();
                loadProps[1].Name = "FilterName";
                loadProps[1].Value = new uno.Any("MS Excel 97");
                loadProps[2] = new PropertyValue();
                loadProps[2].Name = "ReadOnly";
                loadProps[2].Value = new uno.Any(false);
                XComponent document = desktop.loadComponentFromURL(url, "_blank", 0, loadProps);
                XSpreadsheets oSheets = ((XSpreadsheetDocument)document).getSheets();
                XIndexAccess oSheetsIA = (XIndexAccess)oSheets;
                XSpreadsheet sheet = (XSpreadsheet)oSheetsIA.getByIndex(0).Value;
                int ii = 0; XCell celija = null;
                foreach (DataColumn kol in ds.Tables[0].Columns)
                {
                    celija = sheet.getCellByPosition(ii, 0);
                    ((XText)celija).setString(kol.ColumnName);
                    //((XPropertySet)celija).setPropertyValue("CellBackColor", new uno.Any(654321));
                    //((XPropertySet)celija).setPropertyValue("CharColor", new uno.Any(333444));
                    ii++;
                }
                ds.Tables[0].AcceptChanges(); ii = 0;
                foreach (DataRow red in ds.Tables[0].Rows)
                {
                    int jj = 0; ii++;
                    foreach (object ob in red.ItemArray)
                    {
                        celija = sheet.getCellByPosition(jj, ii);
                        ((XText)celija).setString(ob.ToString());
                        //((XPropertySet)celija).setPropertyValue("CellBackColor", new uno.Any(888777));
                        jj++;
                    }
                }
                ((XStorable)document).storeToURL("file:///" + FileName.Replace(@"\", "/"), loadProps);
                System.Diagnostics.Process.Start(FileName);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
