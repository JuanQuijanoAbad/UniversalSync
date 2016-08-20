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

        public AlbumEntity() { }
        public AlbumEntity(string albumName)
        {
            if (!string.IsNullOrWhiteSpace(albumName))
            {
                PartitionKey = albumName;
                RowKey = Guid.NewGuid().ToString();
                Name = albumName;
                Title = "Insert the Title";
                Description = "Insert a description";
                Comment = "Insert a comment";
                Timestamp = DateTimeOffset.UtcNow;
            }
        }
    }
}
