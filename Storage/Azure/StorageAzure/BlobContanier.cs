using Microsoft.WindowsAzure.Storage.Blob;

namespace StorageAzure
{
    public class BlobContanier
    {
        IAzureBlobContainer _appConfig;

        public BlobContanier(IAzureBlobContainer appConfig)
        {
            _appConfig = appConfig;
        }

        public CloudBlobContainer Create()
        {
            return _appConfig.container;
        }
    }
}
