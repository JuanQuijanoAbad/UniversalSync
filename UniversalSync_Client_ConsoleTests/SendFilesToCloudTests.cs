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
        //    [TestMethod()]
        //    public void PutAllFilesTest()
        //    {
        //        var sendFilesToClouds = new SendFilesToCloud(new BlobMock());
        //        var listadoFicheros = new List<string> { @"..\..\20160514_195832.jpg", @"..\..\20160512_194750.mp4" };

        //        try
        //        {
        //            sendFilesToClouds.PutAllFiles(listadoFicheros);
        //        }
        //        catch (Exception ex)
        //        {
        //            Assert.Fail(ex.Message);
        //        }
        //    }
    }

    public class BlobMock : ICloudRepository
    {
        public bool Delete(string fileName)
        {
            try
            { return true; }
            catch (Exception)
            { return false; }
        }
        public Stream Get(string fileName)
        {
            try
            { return new MemoryStream(); }
            catch (Exception)
            { return null; }
        }
        public string Put(FileStream file)
        {
            try
            { return Guid.NewGuid().ToString(); }
            catch (Exception)
            { return new Guid().ToString(); }
        }
    }
}