using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageAzure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class BlobTests
    {
        [TestMethod()]
        public void PutTest()
        {
            var Blob = new Blob();
            var objeto = File.OpenRead(@"C:\Users\jc_qu\Source\Repos\UniversalSync\Storage\Azure\StorageAzureTests\20160514_195832.jpg");

            Blob.Put(objeto);

            objeto.Close();

            Assert.IsTrue(true);
        }
    }
}