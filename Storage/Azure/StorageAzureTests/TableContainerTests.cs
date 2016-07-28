using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class TableContainerTests
    {
        [TestMethod()]
        public void CreateTableContainerTest()
        {
            try
            {
                var config = new ConfigurationTable();
                var resultado = new TableContainer(config).Create();

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            { Assert.Fail(ex.Message); }
        }
    }
}