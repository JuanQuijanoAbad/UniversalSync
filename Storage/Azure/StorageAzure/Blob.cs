using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Blob;
using StorageAzure.Interface;
using System;
using System.IO;

namespace StorageAzure
{
    public class Blob : ICloudRepository
    {
        private CloudBlobContainer _blobContainer { get; }

        public Blob(IAzureConfig config)
        {
            _blobContainer = new BlobContanier(config).Create();
        }

        public string Put(FileStream objeto)
        {
            var fichero = Guid.NewGuid();
            var blob = _blobContainer.GetBlockBlobReference(fichero.ToString());

            blob.UploadFromStream(objeto);

            return fichero.ToString();
        }
        public Boolean Delete(string fileName)
        {
            var blob = _blobContainer.GetBlockBlobReference(fileName);
            return blob.DeleteIfExists();
        }
        public Stream Get(string fileName)
        {
            Stream file = new MemoryStream();
            var blob = _blobContainer.GetBlockBlobReference(fileName);
            blob.DownloadToStream(file);
            return file;
        }
    }
}
