using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IFileService
    {
        Stream ExportFile(string path);
        Task<(string resultPath, string mimeType)> SaveFile(string file);
    }
}
