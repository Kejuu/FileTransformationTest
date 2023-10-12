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

    }
}
