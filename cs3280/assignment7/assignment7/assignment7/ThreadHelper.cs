using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace assignment7
{
    class ThreadHelper
    {
        String output;
        String filePath;
        String fileName;

        public ThreadHelper(String o, String fn)
        {
            output = o;
            fileName = fn;
            filePath = @"C:\Users\Public\";
        }

        public void fileOutput()
        {
            String fileNamePath = filePath + fileName;
            if (File.Exists(fileNamePath))
            {
                MessageBox.Show("This File Already Exists");
            }
            else
            {
                using(StreamWriter MyWriter = new StreamWriter(fileNamePath))
                {
                    MyWriter.Write(output);
                }
            }
        }
    }
}
