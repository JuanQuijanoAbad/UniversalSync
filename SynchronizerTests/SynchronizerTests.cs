using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synchronizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Tests
{
    [TestClass()]
    public class SynchronizerTests
    {
        [TestMethod()]
        public void Synchronizer_Put()
        {
            var path = Path.GetFullPath(@"..\..\20160514_195832.jpg");
            var file = File.OpenRead(path);
            var sincronizador = new Synchronizer();

            var resultadoPut = sincronizador.Put(path, file);

            Assert.AreEqual("204", resultadoPut, "Respuesta: " + resultadoPut);
        }

        [TestMethod()]
        public void Synchronizer_Delete_File_not_exists()
        {
            var path = Path.GetFullPath(@"..\..\no_existe.jpg");
            var sincronizador = new Synchronizer();

            var resultadoPut = sincronizador.DeleteFile(path);

            Assert.AreEqual("404", resultadoPut, "Respuesta: " + resultadoPut);
        }
        [TestMethod()]
        public void Synchronizer_Delete_File_exists()
        {
            var path = Path.GetFullPath(@"..\..\20160514_195832.jpg");
            var sincronizador = new Synchronizer();

            var resultadoPut = sincronizador.DeleteFile(path);

            Assert.AreEqual("204", resultadoPut, "Respuesta: " + resultadoPut);
        }

        [TestMethod()]
        public void Synchronizer_Delete_Album()
        {
            Assert.Inconclusive("Aún no está implementado");
        }

    }
}