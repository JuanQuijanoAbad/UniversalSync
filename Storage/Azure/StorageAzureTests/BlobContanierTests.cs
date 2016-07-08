using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using StorageAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class BlobContanierTests
    {
        [TestMethod()]
        public void CreateContainerTest_desde_parametro()
        {
            var referencia = "juanquijano";
            var blobcontainer = new BlobContanier();

            CloudBlobContainer blob = blobcontainer.Create(referencia);

            Assert.IsNotNull(blob);
            Assert.AreEqual(referencia, blob.Name);
        }
    }
}