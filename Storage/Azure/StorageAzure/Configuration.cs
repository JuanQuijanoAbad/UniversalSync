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
            StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=universalsyncblobcool;AccountKey=bSOOU+bIjYxjgqc1rB9fqAy74so6gC1A+5Ny9CUt6YITGowTFCbA/aKlkI5HHpBVnfZ2/UMX1B/R++WQGeYAvw==";
            ContainerReference = "juanquijano";

            //StorageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            //ContainerReference = CloudConfigurationManager.GetSetting("ContainerReference");
        }
    }

}
