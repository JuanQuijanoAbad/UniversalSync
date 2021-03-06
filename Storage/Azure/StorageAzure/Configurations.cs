﻿using Microsoft.Azure;
using StorageAzure.Interface;

namespace StorageAzure
{
    public class ConfigurationBlob : IAzureConfig
    {
        public string Reference { get; set; }
        public string StorageConnectionString { get; set; }

        public ConfigurationBlob(string reference = "juanquijano")
        {
            StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=universalsyncblobcool;AccountKey=bSOOU+bIjYxjgqc1rB9fqAy74so6gC1A+5Ny9CUt6YITGowTFCbA/aKlkI5HHpBVnfZ2/UMX1B/R++WQGeYAvw==";
            Reference = reference;
        }
    }
    public class ConfigurationTable : IAzureConfig
    {
        public string Reference { get; set; }
        public string StorageConnectionString { get; set; }

        public ConfigurationTable(string tableName)
        {
            StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=universalsynccoordinator;AccountKey=lUnJ8NOwNDUGbkmK+1VCBuuQXOrIj98uGa5MH0L8fDMpYMs+1so6W73XAuaiV7gpz/65I38FJSrEE2+7sRlnxA==";
            Reference = tableName;
        }
        
    }
}
