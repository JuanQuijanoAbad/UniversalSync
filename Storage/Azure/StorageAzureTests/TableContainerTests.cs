using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class TableContainerTests
    {
        [TestMethod()]
        public void Create_Table_Albums_if_not_exist()
        {
            try
            {
                var tableName = "Albums";
                var config = new ConfigurationTable(tableName);
                var resultado = new TableContainer(config).Create();

                Assert.AreEqual(resultado.Name, tableName);
            }
            catch (Exception ex)
            { Assert.Fail(ex.Message); }
        }

        [TestMethod()]
        public void Create_Table_Files_if_not_exist()
        {
            try
            {
                var tableName = "Files";
                var config = new ConfigurationTable(tableName);
                var resultado = new TableContainer(config).Create();

                Assert.AreEqual(resultado.Name, tableName);
            }
            catch (Exception ex)
            { Assert.Fail(ex.Message); }
        }
    }
}