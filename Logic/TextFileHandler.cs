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

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "CHECK_AFT_DATE.TXT"), true))
            {
                foreach (string line in texts) { outputFile.WriteLine(line); }
            }
        }

    }
}
