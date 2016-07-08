using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StorageAzure
{
    public class BlobContanier
    {
        public CloudBlobContainer Create(string containerReference = "")
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            containerReference = GetContainerReference(containerReference);
            CloudBlobContainer container = blobClient.GetContainerReference(containerReference);
            container.CreateIfNotExists();
            return container;
        }

        public string GetContainerReference(string containerReference)
        {
            containerReference = CloudConfigurationManager.GetSetting("ContainerReference") ?? containerReference;
            return containerReference;
        }

    }
}
