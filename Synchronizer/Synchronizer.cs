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

            var albumOps = new AlbumOps(path);
            if (!albumOps.Exist())
            { resultado = albumOps.CreateAlbum(path); }
            var albumId = albumOps.AlbumEntity.RowKey;

            /// Voy a hacerlo con duplicar siempre, despues tengo que añadir el reemplazar que es el verdadero sincronizar
            var repository = new Blob(new ConfigurationBlob());
            var blobId = new BlobOps(repository).Put(file);

            var fileOps = new FileOps(albumId, path, blobId);
            resultado = fileOps.CreateFile();

            return resultado;
        }
        public string DeleteAlbum(string path)
        {
            var albumOps = new AlbumOps(path);
            return albumOps.Delete();
        }
        public string DeleteFile(string path)
        {
            var resultado = "404";
            var albumOps = new AlbumOps(path);

            albumOps.Exist();

            var albumGid = albumOps.AlbumEntity.RowKey;
            var blobId = string.Empty;

            var fileOps = new FileOps(albumGid, path, blobId);
            var files = fileOps.GetFileListByFileName();

            var repository = new Blob(new ConfigurationBlob());
            var blobOps = new BlobOps(repository);

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
        private Table AlbumTable;
        public AlbumEntity AlbumEntity { get; set; }


        public AlbumOps(string path)
        {
            AlbumTable = new Table(new ConfigurationTable("Albums"));
            AlbumEntity = new AlbumEntity();
            AlbumEntity.PartitionKey = GetAlbumName(path);
        }

        public bool Exist()
        {
            var album = AlbumTable.GetAlbumByPartitionKey(AlbumEntity);
            if (album != null)
            { AlbumEntity = (AlbumEntity)album; }

            return album != null; ;
        }
        public string GetAlbumName(string path)
        {
            string fullPath = Path.GetFullPath(path);
            string pathWithoutFile = Path.GetDirectoryName(fullPath).TrimEnd(Path.DirectorySeparatorChar);
            string albumName = pathWithoutFile.Split(Path.DirectorySeparatorChar).Last();

            return albumName;
        }
        public string CreateAlbum(string path)
        {
            var resultado = String.Empty;
            AlbumEntity = new AlbumEntity(GetAlbumName(path));
            resultado = AlbumTable.Put(AlbumEntity);

            return resultado;
        }
        public string Delete()
        {
            var resultado = "400";
            if (Exist())
            { resultado = AlbumTable.Delete(AlbumEntity); }

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
        private ICloudRepository CloudRepository;

        public BlobOps(ICloudRepository cloudRepository)
        {
            CloudRepository = cloudRepository;
        }

        public string Put(FileStream file)
        {
            var blobId = string.Empty;
            blobId = CloudRepository.Put(file);
            file.Close();

            return blobId;
        }
        public bool Delete(string fileGuid)
        {
            var resultado = false;

            resultado = CloudRepository.Delete(fileGuid);

            return resultado;
        }

    }
}
