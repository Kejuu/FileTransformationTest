using FileTransformationTest.Commons;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Logic
{
    public class TextFileHandler
    {
        public TextFileHandler() { }
        public string[] TextFileReader(string filePath) 
        {
            string[] lines = File.ReadAllLines(filePath);

            return lines;
        }
        public void TextFileWriter(string[] texts) 
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"CHECK_AFT_DATE {DateTime.Now.ToString("MM/dd/yyyy").FormatDate()}.TXT"), true))
            {
                foreach (string line in texts) { outputFile.WriteLine(line); }
            }
        }

    }
}
