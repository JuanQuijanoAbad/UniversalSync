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
        public FileEntity FileEntityDePruebas()
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
        public AlbumEntity AlbumEntityDePruebas()
        {
            AlbumEntity entidad = new AlbumEntity();
            entidad.RowKey = "67deda39-a5d3-4620-bb56-1c8b7edcf510";
            entidad.Comment = "Si lo estás viendo, borralo";
            entidad.Description = "Fichero de prueba";
            entidad.Name = "prueba_borrame";
            entidad.ETag = "*";
            entidad.Title = "Borrame";

            return entidad;
        }

        [TestMethod()]
        public void Crud_file_entity()
        {
            var tabla = TablaDePruebas();
            var entidad = FileEntityDePruebas();

            var resultado = tabla.Put(entidad);
            Assert.AreEqual("204", resultado, "Respuesta: " + resultado);

            var resultadoGet = tabla.GetFile(entidad);
            Assert.AreEqual(entidad.RowKey, resultadoGet.RowKey);

            var resultadoDelete = tabla.Delete(entidad);
            Assert.AreEqual("204", resultadoDelete, "Respuesta: " + resultadoDelete);
        }

        [TestMethod()]
        public void Crud_Album_entity()
        {
            var tabla = TablaDePruebas();
            var entidad = AlbumEntityDePruebas();

            var resultado = tabla.Put(entidad);
            Assert.AreEqual("204", resultado, "Respuesta: " + resultado);

            var resultadoGet = tabla.GetAlbum(entidad);
            Assert.AreEqual(entidad.RowKey, resultadoGet.RowKey);

            var resultadoDelete = tabla.Delete(entidad);
            Assert.AreEqual("204", resultadoDelete, "Respuesta: " + resultadoDelete);
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
