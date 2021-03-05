using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.ViewModel;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EBookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        public EBookController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        [Route("GetEBook")]
        public async Task<IActionResult> DownLoadBookAsync([FromQuery] string isbn)
        {
            var dbObject = await _unitOfWork.Books.GetBookAndBookFile(isbn);
            if (dbObject?.BookFile == null || string.IsNullOrEmpty(dbObject.BookFile.Path))
                return NotFound();
            var fileStream = _fileService.ExportFile(dbObject.BookFile.Path);
            if (fileStream == null)
                return NotFound();
            return File(fileStream, "application/octet-stream");
        }

        [HttpPost]
        [Route("AddEBook")]
        public async Task<IActionResult> UploadBookAsync([FromQuery] string isbn, [FromBody] FileUploadViewModel model)
        {
            var dbObject = _unitOfWork.Books.Find(b => b.ISBN == isbn).FirstOrDefault();
            if (dbObject == null)
                return NotFound();
            var filePath = await _fileService.SaveFile(model.file);
            var bookFile = new BookFile
            {
                Book = dbObject,
                Id = dbObject.Id,
                Path = filePath.resultPath,
                MimeType = filePath.mimeType,
                Size = 1522
            };
            await _unitOfWork.BookFiles.AddAsync(bookFile);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}