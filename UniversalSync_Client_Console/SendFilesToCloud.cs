using StorageAzure;
using System.Collections.Generic;
using System.IO;

namespace UniversalSync_Client_Console
{
    public class SendFilesToCloud
    {
        private ICloudRepository CloudRepository;

        public SendFilesToCloud (ICloudRepository cloudRepository)
        {
            CloudRepository = cloudRepository;
        }
        public bool PutAllFiles(List<string> filePaths)
        {
            var resultado = false;

            foreach (var filePath in filePaths)
            {
                resultado = false;
                var file = File.OpenRead(filePath);
                resultado = CloudRepository.Put(file);
            }

            return resultado;
        }

    }
}
