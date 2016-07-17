using System.IO;

namespace StorageAzure
{
    public interface ICloudRepository
    {
        bool Put(FileStream file);
        Stream Get(string fileName);
        bool Delete(string fileName);
    }
}
