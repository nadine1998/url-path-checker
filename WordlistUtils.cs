using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPath
{
    internal class WordlistUtils
    {
        public static List<string> ReadWordListFile(string filePath)
        {
            var words = new List<string>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(" ");
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
