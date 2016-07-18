using System;
using System.IO;
using System.Text;

namespace StorageAzure
{
    public class Blob: ICloudRepository
    {
        IAzureBlobContainer _blobContainer;

        public Blob(IAzureBlobContainer blobContainer)
        {
            _blobContainer = blobContainer;
        }
        public bool Put(FileStream objeto)
        {
            var resultado = false;
            try
            {
                var fichero = Path.GetFileName(objeto.Name);
                var blob = _blobContainer.container.GetBlockBlobReference(fichero);

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
            var blob = _blobContainer.container.GetBlockBlobReference(fileName);
            return blob.DeleteIfExists();
        }
        public Stream Get(string fileName)
        {
            Stream file = new MemoryStream();
            var blob = _blobContainer.container.GetBlockBlobReference(fileName);
            blob.DownloadToStream(file);
            return file;
        }
    }
}
