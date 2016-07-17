using System;
using System.IO;
using System.Text;

namespace StorageAzure
{
    public class Blob: ICloudRepository
    {
        public bool Put(FileStream objeto)
        {
            var resultado = false;
            try
            {
                var fichero = Path.GetFileName(objeto.Name);

                var container = new BlobContanier().Create();
                var blob = container.GetBlockBlobReference(fichero);

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
            var container = new BlobContanier().Create();
            var blob = container.GetBlockBlobReference(fileName);
            return blob.DeleteIfExists();
        }
        public Stream Get(string fileName)
        {
            Stream file = new MemoryStream();
            var container = new BlobContanier().Create();
            var blob = container.GetBlockBlobReference(fileName);
            blob.DownloadToStream(file);
            return file;
        }
    }
}
