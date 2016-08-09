using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace StorageAzure
{
    public class AlbumEntity : TableEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

        public AlbumEntity()
        {
            PartitionKey = "ALBUM";
            RowKey = Guid.NewGuid().ToString();
            Timestamp = DateTime.UtcNow;
        }       
    }
}
