using Microsoft.WindowsAzure.Storage.Table;
using StorageAzure;
using System.IO;
using System.Linq;
using System;

namespace Synchronizer
{
    public class Synchronizer
    {
        public string Put(string path, FileStream file)
        {
            var resultado = string.Empty;
            /// comprueba si es nuevo album
            // recupera el nombre del album
            // busca el nombre del album en tabla Albums
            // si existe, recupera el GUID

            // si no existe, da de alta el nuevo album
            // recupera el GUID

            var albumOps = new AlbumOps(path);

            albumOps.Exist();
            if (albumOps.AlbumEntity.RowKey == null)
            { resultado = albumOps.CreateAlbum(); }

            /// guarda fichero en el blob
            var blobId = new BlobOps().Put(file);

            var fileOps = new FileOps(albumOps.AlbumEntity.RowKey, path, blobId);
            resultado = fileOps.CreateFile();

            /// nueva entrada en Table File con el GUID del album
            /// Voy a hacerlo con duplicar siempre, despues tengo que añadir el reemplazar que es el verdadero sincronizar

   




            return resultado;
        }
        public void Get() { }
        public void GetAll() { }
        public void Delete() { }
    }


    public class AlbumOps
    {
        public AlbumEntity AlbumEntity { get; set; }
        private string _path { get; set; }

        public AlbumOps(string path)
        {
            AlbumEntity = new AlbumEntity();
            _path = path;
            AlbumEntity.PartitionKey = GetAlbumName();
        }

        public AlbumEntity Exist()
        {
            var albumresultado = new AlbumEntity();
            var AlbumTable = new Table(new ConfigurationTable("Albums"));
            var album = AlbumTable.GetAlbumByPartitionKey(AlbumEntity);

            if (album != null)
            {
                AlbumEntity = (AlbumEntity)album;
            }

            return AlbumEntity;
        }
        public string GetAlbumName()
        {
            string fullPath = Path.GetFullPath(_path);
            string pathWithoutFile = Path.GetDirectoryName(fullPath).TrimEnd(Path.DirectorySeparatorChar);
            string albumName = pathWithoutFile.Split(Path.DirectorySeparatorChar).Last();

            return albumName;
        }
        public string CreateAlbum()
        {
            var resultado = String.Empty;
            var album = new AlbumEntity(GetAlbumName());
            var AlbumTable = new Table(new ConfigurationTable("Albums"));
            resultado = AlbumTable.Put(album);

            return resultado;
        }
    }
    public class FileOps
    {
        public FileEntity fileEntity { get; set; }

        public FileOps(string albumGuid, string path, string blobId)
        {
            fileEntity = new FileEntity(albumGuid);
            fileEntity.url = blobId;
            fileEntity.PhysicalPath = Path.GetFullPath(path);
            fileEntity.FileName = Path.GetFileName(path);
            fileEntity.FirstUploadDate = DateTimeOffset.UtcNow;
        }

        public string CreateFile()
        {
            var resultado = string.Empty;
            var FileTable = new Table(new ConfigurationTable("Files"));
            resultado = FileTable.Put(fileEntity);

            return resultado;
        }

    }
    public class BlobOps
    {
        public string Put(FileStream file)
        {
            var blobId = string.Empty;

            var blob = new Blob(new ConfigurationBlob());
            blobId = blob.Put(file);
            file.Close();

            return blobId;
        }

    }
}
