using System;
using StorageAzure;

namespace UniversalSync_Client_Console
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var filesPaths = SelectFolder.RecursiveAndFiles();
            new SendFilesToCloud().PutAllFiles(filesPaths);

            Console.WriteLine("Pulsa una tecla");
            Console.ReadKey();
        }
    }
}
