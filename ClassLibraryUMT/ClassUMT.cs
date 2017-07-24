using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data;

namespace ClassLibraryUMT
{
    public static class ClassUMT
    {
        public static string CyrlToLatn(string tekst)
        {
            var lokal_txt = tekst.Replace("А", "A");
            lokal_txt = lokal_txt.Replace("а", "a");
            lokal_txt = lokal_txt.Replace("Б", "B");
            lokal_txt = lokal_txt.Replace("б", "b");
            lokal_txt = lokal_txt.Replace("В", "V");
            lokal_txt = lokal_txt.Replace("в", "v");
            lokal_txt = lokal_txt.Replace("Г", "G");
            lokal_txt = lokal_txt.Replace("г", "g");
            lokal_txt = lokal_txt.Replace("Д", "D");
            lokal_txt = lokal_txt.Replace("д", "d");

            lokal_txt = lokal_txt.Replace("Ђ", "Đ");
            lokal_txt = lokal_txt.Replace("ђ", "đ");
            lokal_txt = lokal_txt.Replace("Е", "E");
            lokal_txt = lokal_txt.Replace("е", "e");
            lokal_txt = lokal_txt.Replace("Ж", "Ž");
            lokal_txt = lokal_txt.Replace("ж", "ž");
            lokal_txt = lokal_txt.Replace("З", "Z");
            lokal_txt = lokal_txt.Replace("з", "z");
            lokal_txt = lokal_txt.Replace("И", "I");
            lokal_txt = lokal_txt.Replace("и", "i");

            lokal_txt = lokal_txt.Replace("Ј", "J");
            lokal_txt = lokal_txt.Replace("ј", "j");
            lokal_txt = lokal_txt.Replace("К", "K");
            lokal_txt = lokal_txt.Replace("к", "k");
            lokal_txt = lokal_txt.Replace("Л", "L");
            lokal_txt = lokal_txt.Replace("л", "l");
            lokal_txt = lokal_txt.Replace("Љ", "Lj");
            lokal_txt = lokal_txt.Replace("љ", "lj");
            lokal_txt = lokal_txt.Replace("М", "M");
            lokal_txt = lokal_txt.Replace("м", "m");

            lokal_txt = lokal_txt.Replace("Н", "N");
            lokal_txt = lokal_txt.Replace("н", "n");
            lokal_txt = lokal_txt.Replace("Њ", "Nj");
            lokal_txt = lokal_txt.Replace("њ", "nj");
            lokal_txt = lokal_txt.Replace("О", "O");
            lokal_txt = lokal_txt.Replace("о", "o");
            lokal_txt = lokal_txt.Replace("П", "P");
            lokal_txt = lokal_txt.Replace("п", "p");
            lokal_txt = lokal_txt.Replace("Р", "R");
            lokal_txt = lokal_txt.Replace("р", "r");

            lokal_txt = lokal_txt.Replace("С", "S");
            lokal_txt = lokal_txt.Replace("с", "s");
            lokal_txt = lokal_txt.Replace("Т", "T");
            lokal_txt = lokal_txt.Replace("т", "t");
            lokal_txt = lokal_txt.Replace("Ћ", "Ć");
            lokal_txt = lokal_txt.Replace("ћ", "ć");
            lokal_txt = lokal_txt.Replace("У", "U");
            lokal_txt = lokal_txt.Replace("у", "u");
            lokal_txt = lokal_txt.Replace("Ф", "F");
            lokal_txt = lokal_txt.Replace("ф", "f");

            lokal_txt = lokal_txt.Replace("Х", "H");
            lokal_txt = lokal_txt.Replace("х", "h");
            lokal_txt = lokal_txt.Replace("Ц", "C");
            lokal_txt = lokal_txt.Replace("ц", "c");
            lokal_txt = lokal_txt.Replace("Ч", "Č");
            lokal_txt = lokal_txt.Replace("ч", "č");
            lokal_txt = lokal_txt.Replace("Џ", "Dž");
            lokal_txt = lokal_txt.Replace("џ", "dž");
            lokal_txt = lokal_txt.Replace("Ш", "Š");
            lokal_txt = lokal_txt.Replace("ш", "š");

            return lokal_txt;
        }

        public static T2 MapirajMe<T1,T2>(this T1 ulaz)
        {
            var vrati = default(T2);
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<T1, T2>(MemberList.None);
                });
                config.AssertConfigurationIsValid();
                var mapper = config.CreateMapper();
                vrati = mapper.Map<T1, T2>(ulaz);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return vrati;
        }

        public static string DtoToPoco(DataSet ds)
        {
            var objekat = string.Empty;

            objekat += "namespace "+ds.DataSetName + Environment.NewLine;
            objekat += "{" + Environment.NewLine;
            foreach (DataTable tabela in ds.Tables)
            {
                objekat += Environment.NewLine;
                objekat += "public class " + tabela.TableName + Environment.NewLine;
                objekat += "{" + Environment.NewLine;
                foreach (DataColumn kolona in tabela.Columns)
                {
                    objekat += "public " + kolona.DataType.Name + " " + kolona.ColumnName + " {get; set;}" + Environment.NewLine;
                }
                objekat += "}" + Environment.NewLine;
            }
            objekat += "}" + Environment.NewLine;

            return objekat;
        }

        public static DataRow PocoToDtoData<T>(DataRow red, T objekat)
        {
            foreach(var info in typeof(T).GetProperties())
            {
                red[info.Name] = info.GetValue(objekat, null);
            }
            return red;
        }
    }

}
