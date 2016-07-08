using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAzure
{
    public class Blob
    {
        public void Put(FileStream objeto)
        {
            var fichero = Path.GetFileName(objeto.Name);

            var container = new BlobContanier().Create();
            var blob = container.GetBlockBlobReference(fichero);

            blob.UploadFromStream(objeto);
        }
        public Boolean Exist(string fileName)
        {
            var container = new BlobContanier().Create();
            var blob = container.GetBlockBlobReference(fileName);

            return blob.Exists();
        }

        public async Task<Boolean> Delete(string fileName)
        {
            var container = new BlobContanier().Create();
            var blob = container.GetBlockBlobReference(fileName);
            return await blob.DeleteIfExistsAsync();
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
