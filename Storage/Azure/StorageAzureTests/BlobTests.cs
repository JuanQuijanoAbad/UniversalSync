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
            var objeto = File.OpenRead(@"..\..\20160514_195832.jpg");
            var fileName = Path.GetFileName(objeto.Name);

            Blob.Put(objeto);
            objeto.Close();

            Assert.IsTrue(Blob.Exist(fileName));
        }
        [TestMethod()]
        public void ExistTest()
        {
            var Blob = new Blob();
            var fileName = "20160514_195832.jpg";

            Blob.Exist(fileName);

            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void DeleteTest()
        {
            var Blob = new Blob();
            var fileName = "20160514_195832.jpg";

            Blob.Delete(fileName);

            Assert.IsFalse(Blob.Exist(fileName));
        }
    }
}