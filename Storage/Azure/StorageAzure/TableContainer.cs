using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StorageAzure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAzure
{
    public class TableContainer
    {
        IAzureConfig _appConfig;

        public TableContainer(IAzureConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public CloudTable Create()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_appConfig.StorageConnectionString);
            CloudTableClient blobClient = storageAccount.CreateCloudTableClient();
            var table = blobClient.GetTableReference(_appConfig.Reference);
            table.CreateIfNotExists();
            return table;
        }
    }
}
