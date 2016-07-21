using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Blob;
using StorageAzure.Interface;
using System;
using System.IO;

namespace StorageAzure
{
    public class Blob: ICloudRepository
    {
        private CloudBlobContainer _blobContainer { get; }

        public Blob(IAzureConfig config)
        {
            _blobContainer = new BlobContanier(config).Create();
        }            
        
        public bool Put(FileStream objeto)
        {
            var resultado = false;
            try
            {
                var fichero = Path.GetFileName(objeto.Name);
                var blob = _blobContainer.GetBlockBlobReference(fichero);

                blob.UploadFromStream(objeto);
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
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
