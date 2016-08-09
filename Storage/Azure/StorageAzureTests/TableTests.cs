using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table;
using StorageAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAzure.Tests
{
    [TestClass()]
    public class TableTests
    {
        public Table TablaDePruebas()
        {
            var config = new ConfigurationTable("Files");
            var tabla = new Table(config);

            return tabla;
        }
        public FileEntity EntidadDePruebas()
        {
            FileEntity entidad = new FileEntity();
            entidad.RowKey = "67deda39-a5d3-4620-bb56-1c8b7edcf510";
            entidad.Comment = "Si lo estás viendo, borralo";
            entidad.Description = "Fichero de prueba";
            entidad.FileName = "prueba_borrame";
            entidad.ETag = "*";
            entidad.FirstUploadDate = DateTimeOffset.UtcNow;

            return entidad;
        }

        [TestMethod()]
        public void Put_file_entity()
        {
            var tabla = TablaDePruebas();

            var resultado = tabla.Put(EntidadDePruebas());

            Assert.AreEqual("204", resultado, "Respuesta: " + resultado);
        }

        [TestMethod()]
        public void Delete_file_entity()
        {
            var tabla = TablaDePruebas();

            var resultado = tabla.Delete(EntidadDePruebas());

            Assert.AreEqual("204", resultado, "Respuesta: " + resultado);
        }

        [TestMethod()]
        public void Get_file_entity()
        {
            var tabla = TablaDePruebas();
            var entidad = EntidadDePruebas();

            var resultado = tabla.Get(entidad);

            Assert.AreEqual(entidad.RowKey, resultado.RowKey);
        }


        [TestMethod()]
        public void Put_mantiene_la_fecha_del_primer_upload()
        {
            //var config = new ConfigurationTable("Files");
            //var tabla = new Table(config);

            //var resultado = tabla.Put(EntidadDePruebas());

            //Assert.AreEqual("204", resultado, "Respuesta: " + resultado);

            Assert.Inconclusive("No está implementado aún");
        }
    }
}
