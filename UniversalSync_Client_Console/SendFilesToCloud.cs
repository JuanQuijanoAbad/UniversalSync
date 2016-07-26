using StorageAzure;
using System;
using System.Collections.Generic;
using System.IO;

namespace UniversalSync_Client_Console
{
    public class SendFilesToCloud
    {
        private ICloudRepository CloudRepository;

        public SendFilesToCloud(ICloudRepository cloudRepository)
        {
            CloudRepository = cloudRepository;
        }
        public void PutAllFiles(List<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                var file = File.OpenRead(filePath);
                var id = CloudRepository.Put(file);
                Console.WriteLine("Se ha subido el fichero " + Path.GetFileName(filePath) + " con el Id: " + id.ToString());
            }
        }

    }
}
