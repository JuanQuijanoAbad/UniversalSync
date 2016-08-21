using Microsoft.WindowsAzure.Storage.Table;
using StorageAzure.Interface;
using System.Linq;
using System.Collections.Generic;
using System.Data.Services.Client;

namespace StorageAzure
{
    public class Table
    {
        private CloudTable _tableContainer { get; }

        public Table(IAzureConfig config)
        {
            _tableContainer = new TableContainer(config).Create();
        }

        public string Put(TableEntity entity)
        {
            TableOperation insertOperation = TableOperation.InsertOrReplace(entity);
            var resultado = _tableContainer.Execute(insertOperation);
            return resultado.HttpStatusCode.ToString();
        }
        public string Delete(TableEntity entity)
        {
            TableOperation deleteOperation = TableOperation.Delete(entity);
            var resultado = _tableContainer.Execute(deleteOperation);
            return resultado.HttpStatusCode.ToString();
        }

        public TableEntity GetFile(TableEntity fileEntity)
        {
            var query = (from file in _tableContainer.CreateQuery<AlbumEntity>()
                         where file.PartitionKey == fileEntity.PartitionKey
                         && file.RowKey == fileEntity.RowKey
                         select file).FirstOrDefault();
            return query;
        }
        public IQueryable<FileEntity> GetFileListByFileName(FileEntity fileEntity)
        {
            var query = (from file in _tableContainer.CreateQuery<FileEntity>()
                         where file.FileName == fileEntity.FileName
                         select file);
            return query;
        }
        public IQueryable<FileEntity> GetFileListByAlbumAndFileName(FileEntity fileEntity)
        {
            var query = (from file in _tableContainer.CreateQuery<FileEntity>()
                         where file.PartitionKey == fileEntity.PartitionKey 
                         && file.FileName == fileEntity.FileName
                         select file);
            return query;
        }

        public TableEntity GetAlbum(TableEntity albumEntity)
        {
            var query = (from album in _tableContainer.CreateQuery<AlbumEntity>()
                         where album.PartitionKey == albumEntity.PartitionKey
                         && album.RowKey == albumEntity.RowKey
                         select album).FirstOrDefault();
            return query;
        }
        public TableEntity GetAlbumByPartitionKey(TableEntity albumEntity)
        {
            var query = (from album in _tableContainer.CreateQuery<AlbumEntity>()
                         where album.PartitionKey == albumEntity.PartitionKey
                         select album).FirstOrDefault();

            return query;
        }
    }
}
