using Microsoft.Azure;
using StorageAzure.Interface;

namespace StorageAzure.Tests
{
    public class ConfigurationToTest : IAzureConfig
    {
        public string Reference { get; set; }
        public string StorageConnectionString { get; set; }

        public ConfigurationToTest()
        {
            StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=universalsyncblobcool;AccountKey=bSOOU+bIjYxjgqc1rB9fqAy74so6gC1A+5Ny9CUt6YITGowTFCbA/aKlkI5HHpBVnfZ2/UMX1B/R++WQGeYAvw==";
            Reference = "juanquijano";
        }
    }
}
