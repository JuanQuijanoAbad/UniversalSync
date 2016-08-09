using Microsoft.WindowsAzure.Storage.Table;
using StorageAzure.Interface;
using System.Collections.Generic;

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
        public TableEntity Get(TableEntity entity)
        {
           //IEnumerable<FileEntity> query = (from item in _tableContainer.CreateQuery<FileEntity>()
           //                 select item).Take(1);

            return null;
        }
    }
}
