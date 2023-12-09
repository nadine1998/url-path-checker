using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPath
{
    internal class CsvUtils
    {
        public static List<string> ReadCsvFile(string filePath)
        {
            var words = new List<string>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    words.AddRange(fields);
                }
            }
            return words;
        }

    }
}
