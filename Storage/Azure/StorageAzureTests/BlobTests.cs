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
            var objeto = Stream.Null;

            var resultado = Blob.Put(objeto);

            Assert.IsTrue(resultado);
        }
    }
}