using Microsoft.WindowsAzure.Storage.Table;
using StorageAzure;
using System.IO;
using System.Linq;

namespace Synchronizer
{
    public class Synchronizer
    {
        public string Put(string path, FileStream file)
        {
            /// comprueba si es nuevo album
            // recupera el nombre del album
            // busca el nombre del album en tabla Albums
            // si existe, recupera el GUID

            var AlbumId = new AlbumOps(path).Exist();

            // si no existe, da de alta el nuevo album
            // recupera el GUID

            /// nueva entrada en Table File con el GUID del album

            /// guarda fichero en el blob

            return "204";
        }
        public void Get() { }
        public void GetAll() { }
        public void Delete() { }
    }

    public class AlbumOps
    {
        private AlbumEntity entidad { get; set; }
        private string _path { get; set; }

        public AlbumOps(string path)
        {
            entidad = new AlbumEntity();
            _path = path;
            entidad.PartitionKey = GetAlbumName();
        }

        public AlbumEntity Exist()
        {
            var albumresultado = new AlbumEntity();
            var AlbumTable = new Table(new ConfigurationTable("Albums"));
            var album = AlbumTable.GetAlbumByPartitionKey(entidad);

            if (album != null)
            {
                entidad = (AlbumEntity) album;}

            return entidad;
        }
        public string GetAlbumName()
        {
            string fullPath = Path.GetFullPath(_path);
            string pathWithoutFile = Path.GetDirectoryName(fullPath).TrimEnd(Path.DirectorySeparatorChar);
            string albumName = pathWithoutFile.Split(Path.DirectorySeparatorChar).Last();

            return albumName;
        }
    }

}
