using Microsoft.Azure;
using StorageAzure.Interface;

namespace StorageAzure.Tests
{
    public class ConfigurationToTest : IAzureConfig
    {
        public string ContainerReference { get; set; }
        public string StorageConnectionString { get; set; }

        public ConfigurationToTest()
        {
            StorageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            ContainerReference = CloudConfigurationManager.GetSetting("ContainerReference");
        }
    }
}
