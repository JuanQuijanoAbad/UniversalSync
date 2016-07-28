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
            var blobContainer = new BlobContanier(new ConfigurationToTest()).Create();
            var blob = blobContainer.GetBlockBlobReference(fileName);

            return blob.Exists();
        }
        //[TestMethod()]
        public void BlobDelete(string guid)
        {
            var blob = new Blob(new ConfigurationToTest());

            blob.Delete(guid);

            Assert.IsFalse(Exist(guid));
        }

        [TestMethod()]
        public void BlobPut()
        {
            var blob = new Blob(new ConfigurationToTest());
            var objeto = File.OpenRead(@"..\..\20160514_195832.jpg");

            string id = blob.Put(objeto);
            objeto.Close();

            Assert.IsFalse(id == new Guid().ToString());
            Assert.IsTrue(Exist(id.ToString()));

            BlobDelete(id);
        }
        [TestMethod()]
        public void BlobPut_Fichero_de_55_Mb()
        {
            var blob = new Blob(new ConfigurationToTest());
            var objeto = File.OpenRead(@"..\..\20160512_194750.mp4");

            string id = blob.Put(objeto);
            objeto.Close();

            Assert.IsFalse(id == new Guid().ToString());
            Assert.IsTrue(Exist(id.ToString()));

            BlobDelete(id);
        }
    }
}