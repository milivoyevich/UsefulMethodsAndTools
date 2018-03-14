using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace ClassLibraryUMT.Metode
{
    class ExcelClass
    {
        public static void exportToExcel(DataSet source, string fileName)
        {
            System.IO.StreamWriter excelDoc;
            int[] sir_kol = new int[150];
            excelDoc = new System.IO.StreamWriter(fileName);
            const string startExcelXML = "<?xml version=\"1.0\"?>\r\n<?mso-application progid=\"Excel.Sheet\"?>\r\n<Workbook " +
                  "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                  " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                  "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                  "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                  "office:spreadsheet\"\r\n xmlns:html=\"http://www.w3.org/TR/REC-html40\"\r\n"+
                  " xmlns:u1=\"urn:schemas-    microsoft-com:office:excel\">\r\n<Styles>\r\n " +
                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                  "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                  "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                  "\r\n <Protection/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                  "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                  "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                  " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                  "ss:Format=\"0.00\"/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                  "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                  "ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n " +
                  "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            int sheetCount = 1;
            /*
           <xml version>
           <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
           xmlns:o="urn:schemas-microsoft-com:office:office"
           xmlns:x="urn:schemas-microsoft-com:office:excel"
           xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
           <Styles>
           <Style ss:ID="Default" ss:Name="Normal">
             <Alignment ss:Vertical="Bottom"/>
             <Borders/>
             <Font/>
             <Interior/>
             <NumberFormat/>
             <Protection/>
           </Style>
           <Style ss:ID="BoldColumn">
             <Font x:Family="Swiss" ss:Bold="1"/>
           </Style>
           <Style ss:ID="StringLiteral">
             <NumberFormat ss:Format="@"/>
           </Style>
           <Style ss:ID="Decimal">
             <NumberFormat ss:Format="0.0000"/>
           </Style>
           <Style ss:ID="Integer">
             <NumberFormat ss:Format="0"/>
           </Style>
           <Style ss:ID="DateLiteral">
             <NumberFormat ss:Format="mm/dd/yyyy;@"/>
           </Style>
           </Styles>
           <Worksheet ss:Name="Sheet1">
           </Worksheet>
           </Workbook>
           */
            excelDoc.Write(startExcelXML);
            for (int broj = 0; broj < source.Tables.Count;broj++ )
            {
                //sheetCount = sheetCount + broj;
                excelDoc.Write("<Worksheet ss:Name=\"" + source.Tables[broj].TableName+"_"+ sheetCount + "\">");
                excelDoc.Write("<Table ss:ExpandedColumnCount=\"" + (source.Tables[broj].Columns.Count-1).ToString() +
                    "\" ss:ExpandedRowCount=\"" + (source.Tables[broj].Rows.Count+1).ToString() + 
                    "\" x:FullColumns=\"1\" x:FullRows=\"1\">\r\n");
                foreach (DataRow x in source.Tables[broj].Rows)
                {
                    for (int cx = 0; cx < source.Tables[broj].Columns.Count; cx++)
                    {
                        if (sir_kol[cx] < x[cx].ToString().Trim().Length) sir_kol[cx] = x[cx].ToString().Length;
                    }
                }
                for (int cx = 0; cx < source.Tables[broj].Columns.Count; cx++)
                {
                    sir_kol[cx] = sir_kol[cx] > source.Tables[broj].Columns[cx].Caption.Trim().Length ? sir_kol[cx] : source.Tables[broj].Columns[cx].Caption.Trim().Length;
                    sir_kol[cx] = sir_kol[cx] > 1 ? sir_kol[cx] : 1;
                    excelDoc.Write("<Column ss:Width=\""+sir_kol[cx]*6+"\"/>");
                }
                excelDoc.Write("<Row>\r\n");
                for (int x = 0; x < source.Tables[broj].Columns.Count; x++)
                {
                    excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                    excelDoc.Write(source.Tables[broj].Columns[x].Caption);
                    excelDoc.Write("</Data></Cell>\r\n");                
                }
                excelDoc.Write("</Row>\r\n");
            
                foreach (DataRow x in source.Tables[broj].Rows)
                {
                    rowCount++;
                    //if the number of rows is > 64000 create a new page to continue output

                    if (rowCount == 64000)
                    {
                        rowCount = 0;
                        sheetCount++;
                        excelDoc.Write("</Table>\r\n");
                        excelDoc.Write(" </Worksheet>\r\n");
                        excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">\r\n");
                        excelDoc.Write("<Table>\r\n");
                    }
                    excelDoc.Write("<Row>\r\n"); //ID=" + rowCount + "
                    
                    for (int y = 0; y < source.Tables[broj].Columns.Count; y++)
                    {
                        System.Type rowType;
                        rowType = x[y].GetType();
                        switch (rowType.ToString())
                        {
                            case "System.Guid":
                            case "System.String":
                                string XMLstring = x[y].ToString();
                                XMLstring = XMLstring.Trim();
                                XMLstring = XMLstring.Replace("&", "&");
                                XMLstring = XMLstring.Replace(">", ">");
                                XMLstring = XMLstring.Replace("<", "<");
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                               "<Data ss:Type=\"String\">");
                                excelDoc.Write(XMLstring);
                                excelDoc.Write("</Data></Cell>\r\n");
                                break;
                            case "System.DateTime":
                                //Excel has a specific Date Format of YYYY-MM-DD followed by  

                                //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000

                                //The Following Code puts the date stored in XMLDate 

                                //to the format above

                                DateTime XMLDate = (DateTime)x[y];
                                string XMLDatetoString = ""; //Excel Converted Date

                                XMLDatetoString = XMLDate.Year.ToString() +
                                     "-" +
                                     (XMLDate.Month < 10 ? "0" +
                                     XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                     "-" +
                                     (XMLDate.Day < 10 ? "0" +
                                     XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                     "T" +
                                     (XMLDate.Hour < 10 ? "0" +
                                     XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                     ":" +
                                     (XMLDate.Minute < 10 ? "0" +
                                     XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                     ":" +
                                     (XMLDate.Second < 10 ? "0" +
                                     XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                     ".000";
                                excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                             "<Data ss:Type=\"DateTime\">");
                                excelDoc.Write(XMLDatetoString);
                                excelDoc.Write("</Data></Cell>\r\n");
                                break;
                            case "System.Boolean":
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                            "<Data ss:Type=\"String\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>\r\n");
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                        "<Data ss:Type=\"Number\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>\r\n");
                                break;
                            case "System.Single":
                            case "System.Decimal":
                            case "System.Double":
                                excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                      "<Data ss:Type=\"Number\">");
                                excelDoc.Write(x[y].ToString().Replace(",","."));
                                excelDoc.Write("</Data></Cell>\r\n");
                                break;
                            case "System.DBNull":
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                      "<Data ss:Type=\"String\">");
                                excelDoc.Write("");
                                excelDoc.Write("</Data></Cell>\r\n");
                                break;
                            default:
                                throw (new Exception(rowType.ToString() + " not handled."));
                        }
                    }
                    excelDoc.Write("</Row>\r\n");
                }
                excelDoc.Write("</Table>\r\n");
                excelDoc.Write(" </Worksheet>");
                sheetCount++;
            }
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
        }
    }
}
