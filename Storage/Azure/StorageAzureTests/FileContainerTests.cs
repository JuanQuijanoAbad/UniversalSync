using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.File;
using StorageAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class FileContainerTests
    {
        [TestMethod()]
        public void FileContainer_Create()
        {
            var fileContainer = new FileContainer();

            CloudFileShare resultado = fileContainer.Create();

            Assert.IsTrue(resultado.Exists());
        }
    }
}