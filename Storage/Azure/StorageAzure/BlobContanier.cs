using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StorageAzure.Interface;

namespace StorageAzure
{
    public class BlobContanier
    {
        IAzureConfig _appConfig;

        public BlobContanier(IAzureConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public CloudBlobContainer Create()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_appConfig.StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(_appConfig.ContainerReference);
            container.CreateIfNotExists();
            return container;
        }
    }
}
