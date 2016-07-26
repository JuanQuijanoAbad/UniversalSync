using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace StorageAzure
{
    public interface ICloudRepository
    {
        Guid Put(FileStream file);
        Stream Get(string fileName);
        bool Delete(string fileName);
    }
}
