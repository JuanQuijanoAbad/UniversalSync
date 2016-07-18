using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class BlobTests
    {
        public Boolean Exist(string fileName)
        {
            var blobContainer = new GetBlobContainer();
            var blob = blobContainer.container.GetBlockBlobReference(fileName);

            return blob.Exists();
        }

        //[TestMethod()]
        public void BlobPut()
        {
            var blob = new Blob(new GetBlobContainer());
            var objeto = File.OpenRead(@"..\..\20160514_195832.jpg");
            var fileName = Path.GetFileName(objeto.Name);

            blob.Put(objeto);
            objeto.Close();

            Assert.IsTrue(Exist(fileName));
        }
        //[TestMethod()]
        public void BlobPut_Fichero_de_55_Mb()
        {
            var blob = new Blob(new GetBlobContainer());
            var objeto = File.OpenRead(@"..\..\20160512_194750.mp4");
            var fileName = Path.GetFileName(objeto.Name);

            blob.Put(objeto);
            objeto.Close();

            Assert.IsTrue(Exist(fileName));
        }
        //[TestMethod()]
        public void BlobGet()
        {
            var blob = new Blob(new GetBlobContainer());
            var fileName = "20160514_195832.jpg";

            var fichero = blob.Get(fileName);

            Assert.IsNotNull(fichero);
            Assert.IsTrue(fichero.Length > 0);
        }
        //[TestMethod()]
        public void BlobDelete(string fichero)
        {
            var blob = new Blob(new GetBlobContainer());

            blob.Delete(fichero);

            Assert.IsFalse(Exist(fichero));
        }

        [TestMethod()]
        public void Operaciones_CRUD_en_el_Azure_Blob()
        {
            var blob = new Blob(new GetBlobContainer());
            var imagen = "20160514_195832.jpg";
            var video = "20160512_194750.mp4";

            BlobPut();
            BlobGet();
            BlobPut_Fichero_de_55_Mb();
            blob.Delete(imagen);
            blob.Delete(video);
        }
    }
}