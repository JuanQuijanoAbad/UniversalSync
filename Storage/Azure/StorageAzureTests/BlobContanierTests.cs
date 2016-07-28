using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class BlobContanierTests
    {
        [TestMethod()]
        public void CreateBlobContainer()
        {
            var container = new BlobContanier(new ConfigurationToTest()).Create();

            Assert.IsNotNull(container);
        }
    }
}