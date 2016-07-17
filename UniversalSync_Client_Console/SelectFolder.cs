using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalSync_Client_Console
{
    class SelectFolder
    {
        public static List<string> RecursiveAndFiles()
        {
            var filesPaths = new List<string>();
            var numFiles = 0;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Directorio principal: " + fbd.SelectedPath);
                foreach (var path in Directory.GetFiles(fbd.SelectedPath))
                {
                    Console.WriteLine(Path.GetFileName(path));
                    filesPaths.Add(path);
                    numFiles++;
                }
                foreach (var directorio in Directory.GetDirectories(fbd.SelectedPath))
                {
                    Console.WriteLine(directorio);
                    foreach (var path in Directory.GetFiles(directorio))
                    {
                        filesPaths.Add(path);
                    }
                    numFiles++;
                }
                Console.WriteLine("Numero de ficheros totáles: " + numFiles);
            }

            return filesPaths;
        }
    }
}
