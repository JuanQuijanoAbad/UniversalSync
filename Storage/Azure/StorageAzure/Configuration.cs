using Microsoft.Azure;
using StorageAzure.Interface;

namespace StorageAzure
{
    public class Configuration : IAzureConfig
    {
        public string ContainerReference { get; set; }
        public string StorageConnectionString { get; set; }

        public Configuration()
        {
            StorageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            ContainerReference = CloudConfigurationManager.GetSetting("ContainerReference");
        }
    }

}
