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
            // si no existe, da de alta el nuevo album
            // recupera el GUID

            var albumOps = new AlbumOps(path);

            albumOps.Exist();
            if (albumOps.AlbumEntity.RowKey == null)
            { resultado = albumOps.CreateAlbum(); }

            /// guarda fichero en el blob
            /// Voy a hacerlo con duplicar siempre, despues tengo que añadir el reemplazar que es el verdadero sincronizar
            var blobId = new BlobOps().Put(file);

            /// nueva entrada en Table File con el GUID del album y el GUID del blob en la propiedad url
            var fileOps = new FileOps(albumOps.AlbumEntity.RowKey, path, blobId);
            resultado = fileOps.CreateFile();

            return resultado;
        }


        public void Get() { }
        public void GetAll() { }
        public void Delete() { }
        public string DeleteFile(string path)
        {
            var resultado = "404";
            var albumOps = new AlbumOps(path);

            albumOps.Exist();

            var albumGid = albumOps.AlbumEntity.RowKey;
            var blobId = string.Empty;

            var blobOps = new BlobOps();

            var fileOps = new FileOps(albumGid, path, blobId);
            var files = fileOps.GetFileListByFileName();

            foreach (var item in files)
            {
                blobOps.Delete(item.url);
                resultado = fileOps.Delete(item);
            }

            return resultado;
        }
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
        private Table fileTable { get; set; }


        public FileOps(string albumGuid, string path, string blobId)
        {
            fileTable = new Table(new ConfigurationTable("Files"));
            fileEntity = new FileEntity(albumGuid);
            fileEntity.url = blobId;
            fileEntity.PhysicalPath = Path.GetFullPath(path);
            fileEntity.FileName = Path.GetFileName(path);
            fileEntity.FirstUploadDate = DateTimeOffset.UtcNow;
        }

        public string CreateFile()
        {
            var resultado = string.Empty;
            var fileTable = new Table(new ConfigurationTable("Files"));
            resultado = fileTable.Put(fileEntity);

            return resultado;
        }
        public IQueryable<FileEntity> GetFileListByFileName()
        {
            var fileList = fileTable.GetFileListByFileName(fileEntity);
            return fileList;
        }
        public string Delete(FileEntity entity)
        {
            string resultado = string.Empty;
            resultado = fileTable.Delete(entity);

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
        public bool Delete(string fileGuid)
        {
            var resultado = false;

            var blob = new Blob(new ConfigurationBlob());
            resultado = blob.Delete(fileGuid);

            return resultado;
        }

    }
}
