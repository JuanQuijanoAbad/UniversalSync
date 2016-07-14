using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class BlobTests
    {
        public Boolean Exist(string fileName)
        {
            var container = new BlobContanier().Create();
            var blob = container.GetBlockBlobReference(fileName);

            return blob.Exists();
        }

        [TestMethod()]
        public void BlobPut()
        {
            var blob = new Blob();
            var objeto = File.OpenRead(@"..\..\20160514_195832.jpg");
            var fileName = Path.GetFileName(objeto.Name);

            blob.Put(objeto);
            objeto.Close();

            Assert.IsTrue(Exist(fileName));
        }
        [TestMethod()]
        public void BlobGet()
        {
            var blob = new Blob();
            var fileName = "20160514_195832.jpg";
            
            var fichero = blob.Get(fileName);
            
            Assert.IsNotNull(fichero);
            Assert.IsTrue(fichero.Length > 0);
        }
        [TestMethod()]
        public void BlobDelete()
        {
            var blob = new Blob();
            var fileName = "20160514_195832.jpg";

            blob.Delete(fileName);

            Assert.IsFalse(Exist(fileName));
        }
    }
}