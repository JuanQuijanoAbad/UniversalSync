using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageAzure.Tests;
using Synchronizer;

namespace Synchronizer.Tests
{
    [TestClass()]
    public class AlbumOpsTests
    {
        [TestMethod()]
        public void GetAlbumName_fullPath()
        {
            var path = @"C:\Users\juan.c.quijano.abad\Source\Repos\UniversalSync\SynchronizerTests\20160514_195832.jpg";
            var albumOps = new AlbumOps(path);

            var resultado = albumOps.GetAlbumName(path);

            Assert.AreEqual("SynchronizerTests", resultado, "Ha devuelto: " + resultado + " como nombre de Album");
        }
        [TestMethod()]
        public void GetAlbumName_RelativePath()
        {
            var path = @"..\..\20160514_195832.jpg";
            var albumOps = new AlbumOps(path);

            var resultado = albumOps.GetAlbumName(path);

            Assert.AreEqual("SynchronizerTests", resultado, "Ha devuelto: " + resultado + " como nombre de Album");
        }
        [TestMethod()]
        public void GetAlbumName_fullPath_end_slash()
        {
            var path = @"C:\Users\juan.c.quijano.abad\Source\Repos\UniversalSync\SynchronizerTests\";
            var albumOps = new AlbumOps(path);

            var resultado = albumOps.GetAlbumName(path);

            Assert.AreEqual("SynchronizerTests", resultado, "Ha devuelto: " + resultado + " como nombre de Album");
        }
        [TestMethod()]
        public void GetAlbumName_RelativePath_with_double_slash()
        {
            var path = @"..\\..\\20160514_195832.jpg";
            var albumOps = new AlbumOps(path);

            var resultado = albumOps.GetAlbumName(path);

            Assert.AreEqual("SynchronizerTests", resultado, "Ha devuelto: " + resultado + " como nombre de Album");
        }
        [TestMethod()]
        public void GetAlbumName_without_root()
        {
            var path = @"..\\..\\20160514_195832.jpg";
            var albumOps = new AlbumOps(path);

            var resultado = albumOps.GetAlbumName(path);

            Assert.AreEqual("SynchronizerTests", resultado, "Ha devuelto: " + resultado + " como nombre de Album");
        }


        [TestMethod()]
        public void Exist_is_false()
        {
            var path = @"..\\noexiste\\20160514_195832.jpg";
            var albumOps = new AlbumOps(path);

            var resultado = albumOps.Exist();

            Assert.IsFalse(resultado);
        }
        [TestMethod()]
        public void Exist_is_true()
        {
            var path = @"..\\Borrame\\20160514_195832.jpg";
            var albumOps = new AlbumOps(path);
            var tableOps = new TableTests();
            var tabla = tableOps.TablaDePruebas("Albums");
            var entidad = tableOps.AlbumEntityDePruebas();

            tabla.Put(entidad);
            var resultado = albumOps.Exist();
            tabla.Delete(entidad);

            Assert.IsTrue(resultado);
        }

        public void AlbumOps_DeleteAlbum()
        {
            var path = @"C:\Users\juan.c.quijano.abad\Source\Repos\UniversalSync\SynchronizerTests\20160514_195832.jpg";
            var albumOps = new AlbumOps(path);

            var resultado = albumOps.Delete();

            Assert.AreEqual("204", resultado, "No ha encontrado el Album SynchronizerTests para borrarlo");
        }
    }
}