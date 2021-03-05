using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ApiServices.Configuration;
using Domain.Entities;
using Domain.Interface;
using Microsoft.Extensions.Options;
using Repository.UnitOfWork;

namespace ApiServices.Services
{
    public class FileService : IFileService
    {
        private readonly IOptions<FileServiceConfiguration> _options;
        public FileService(
            IOptions<FileServiceConfiguration> options)
        {
            _options = options;
        }
        public Stream ExportFile(string path)
        {
            return File.OpenRead(path);
        }

        public async Task<(string resultPath, string mimeType)> SaveFile(string file)
        {
            var fileType = file.Substring(0, 5);
            if (fileType == "JVBER") fileType = "PDF";
            var resultPath = $@"{_options.Value.FileStoragePath}\{Guid.NewGuid()}.{fileType}";
            await File.WriteAllBytesAsync(resultPath, Convert.FromBase64String(file));
            return (resultPath, fileType);
        }
    }
}
