using Microsoft.WindowsAzure.Storage.Table;
using StorageAzure.Interface;
using System;
using System.IO;

namespace StorageAzure
{
    public class Table : ICloudRepository
    {
        private CloudTable _tableContainer { get; }

        public Table(IAzureConfig config)
        {
            _tableContainer = new TableContainer(config).Create();
        }

        public string Put(FileStream objeto)
        {
            var fichero = string.Empty;
            //var blob = _blobContainer.GetBlockBlobReference(fichero.ToString());

            //blob.UploadFromStream(objeto);

            return fichero;
        }
        public Boolean Delete(string fileName)
        {
            //var blob = _blobContainer.GetBlockBlobReference(fileName);
            //return blob.DeleteIfExists();
            return false;
        }
        public Stream Get(string fileName)
        {
            Stream file = new MemoryStream();
            //var blob = _blobContainer.GetBlockBlobReference(fileName);
            //blob.DownloadToStream(file);
            return file;
        }
    }
}
