using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace StorageAzure
{
    public interface ICloudRepository
    {
        bool Put(FileStream file);
        Stream Get(string fileName);
        bool Delete(string fileName);
    }

    public interface IAzureBlobContainer
    {
        string StorageConnectionString { get; set; }
        string ContainerReference { get; set; }
        CloudBlobContainer container { get; set; }
    }
}
