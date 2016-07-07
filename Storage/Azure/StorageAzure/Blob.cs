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

            blob.UploadFromStreamAsync(objeto);
        }
    }
}
