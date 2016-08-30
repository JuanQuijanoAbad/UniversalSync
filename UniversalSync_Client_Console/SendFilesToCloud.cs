using System;
using System.Collections.Generic;
using System.IO;

namespace UniversalSync_Client_Console
{
    public class SendFilesToCloud
    {

        public void PutAllFiles(List<string> filePaths)
        {
            var syncro = new Synchronizer.Synchronizer();

            foreach (var filePath in filePaths)
            {
                var file = File.OpenRead(filePath);
                syncro.Put(filePath, file);

                Console.WriteLine("Se ha subido el fichero " + Path.GetFileName(filePath));
            }
        }
    }
}
