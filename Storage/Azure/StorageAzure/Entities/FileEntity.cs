using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace StorageAzure
{
    public class FileEntity : TableEntity
    {
        public string FileName { get; set; }
        public string url { get; set; }
        public string PhysicalPath { get; set; }
        public DateTimeOffset FirstUploadDate { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Tags { get; set; }
        public string Geoposition { get; set; }

        public FileEntity()
        {
            PartitionKey = new Guid().ToString();
            RowKey = Guid.NewGuid().ToString();
            Timestamp = DateTimeOffset.UtcNow;
        }
        public FileEntity(string AlbumGuiPartitionKey)
        {
            if (string.IsNullOrWhiteSpace(AlbumGuiPartitionKey))
            { PartitionKey = new Guid().ToString(); }
            else
            { PartitionKey = AlbumGuiPartitionKey; }

            RowKey = Guid.NewGuid().ToString();
            Timestamp = DateTimeOffset.UtcNow;
        }
    }
}
