using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StorageAzure;

namespace StorageAzureTests
{
    public class GetBlobContainer : IAzureBlobContainer
    {
        public string StorageConnectionString { get; set; }
        public string ContainerReference { get; set; }
        public CloudBlobContainer container { get; set; }

        public GetBlobContainer()
        {
            StorageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            ContainerReference = CloudConfigurationManager.GetSetting("ContainerReference");
            Create();
        }

        private void Create()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference(ContainerReference);
            container.CreateIfNotExists();
        }
    }
}
