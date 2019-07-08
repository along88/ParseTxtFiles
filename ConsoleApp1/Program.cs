using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            //A quick script I whipped together that will read a txt file, and create a new line for each string entry seperated by a whitespace
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            
            List<string> newLine = new List<string>();
            var lines = "";
            List<string> parsedLines = new List<string>();

            using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName))
                while ((lines = sr.ReadLine()) != null)
                    newLine.Add(lines); // Add to list.

            
            foreach (var line in newLine)
            {
                var splitLines = line.Split(' ');
                for (int i = 0; i < splitLines.Length; i++)
                    if(!string.IsNullOrEmpty(splitLines[i]))
                        parsedLines.Add(splitLines[i]);
                

            }

            var newLocation = @System.Environment.CurrentDirectory+"/parsedCodes.txt";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(newLocation))
                foreach(var item in parsedLines)
                    sw.WriteLine(item.ToString());
            

        }
    }
}
