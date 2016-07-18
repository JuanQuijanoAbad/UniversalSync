using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class BlobContanierTests
    {
        [TestMethod()]
        public void CreateContainer()
        {
            var blobContainer = new GetBlobContainer();

            Assert.IsNotNull(blobContainer.container);
        }
    }
}