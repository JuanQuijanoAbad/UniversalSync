using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using StorageAzure;
using System.Collections.Generic;

namespace UniversalSync_Client_Console.Tests
{
    [TestClass()]
    public class SendFilesToCloudTests
    {
        [TestMethod()]
        public void PutAllFilesTest()
        {
            var sendFilesToClouds = new SendFilesToCloud(new BlobMock());
            var listadoFicheros = new List<string> { @"..\..\20160514_195832.jpg", @"..\..\20160512_194750.mp4" };

            var resultado = sendFilesToClouds.PutAllFiles(listadoFicheros);

            Assert.IsTrue(resultado);
        }
    }

    public class BlobMock : ICloudRepository
    {
        public bool Delete(string fileName)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Stream Get(string fileName)
        {
            try
            {
                return new MemoryStream();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Put(FileStream file)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}