using Diary.UI.DataContext;
using Diary.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Diary.UI.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index( int ?  Id)
        {

            if (Id == null)
            {
                Id = 1;
            }
            var documents = await _context.Documents.Where(f => f.Lawsuit == Id).ToListAsync();
            return View(documents);
        }
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile FormFile)
        {
            byte[] Content;


            string filename = Path.GetFileName(FormFile.FileName);
            string contentType = FormFile.ContentType;

            using (var memoryStream = new MemoryStream())
            {
                await FormFile.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                {

                    Content = memoryStream.ToArray();
                    Document document = new Document()
                    {
                        Lawsuit = 1,
                        Data = Content,
                        fileName = filename,
                        ContentType = contentType
                    };

                    _context.Documents.Add(document);
                    _context.SaveChanges();

                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return RedirectToAction("Index", "Home");

        }
        public async Task<FileResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _context.Documents.FindAsync(id);

            if (file == null) return null;
            return File(file.Data, file.ContentType, file.fileName);
        }
        byte[] ReadFile(string sPath)
        {
            
            byte[] data = null;            
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;            
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);        
            data = br.ReadBytes((int)numBytes);
            return data;
        }

    }
}
