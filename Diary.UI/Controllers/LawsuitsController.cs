using Diary.UI.DataContext;
using Diary.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Diary.UI.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class LawsuitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LawsuitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lawsuits
        public IActionResult Index()
        {
            var item = _context.Lawsuits.Select(x => new LawsuitViewModel()
            {
                Id = x.Id,
                Customer = x.Customers.Select(x => x.ClientName).FirstOrDefault(),
                CaseCategory = x.CaseCategory.Category,
                Court = x.Courts.CourtName,
                Description = x.Description,
                Casetype = x.Casetype.ToString(),
                CreateOn = x.CreateOn,
                Status = x.Status.ToString()

            }).AsEnumerable();


            var TodayCases = item.Where(x => x.CreateOn.Equals(DateTime.Now));
            var nextdayacases= item;
            return View(nextdayacases.ToList());
        }

      
        // GET: Lawsuits/Create
        public IActionResult Create()
        {
            var model = new LawsuitInputModel()
            {
                CategoryList= (List<SelectListItem>)_context.CaseCategories.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Category }).ToList(),
                ApplicationUserList = (List<SelectListItem>)_context.ApplicationUsers.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                CourtList = (List<SelectListItem>)_context.Court.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CourtName }).ToList(),
                CustomersList = (List<SelectListItem>)_context.Customers.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.ClientName }).ToList()
            };
            return View(model);
        }

        // POST: Lawsuits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LawsuitInputModel item)
        {
            if (ModelState.IsValid)
            {

                var lawsuit = new Lawsuit()
                {
                    Courts = _context.Court.Find(item.CourtsId),
                    FileNo=item.FileNo,
                    CaseCategory= _context.CaseCategories.Find(item.CategoryId),
                    Description = item.Description,
                    Casetype = item.Casetype,
                    Status = item.Status,
                    ApplicationUser = _context.ApplicationUsers.Find(item.ApplicationUserId),
                    CreateOn=DateTime.Today
                };


                _context.Add(lawsuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Lawsuits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            

            var lawsuit = await _context.Lawsuits.Where(x => x.Id == id).Select(x => new LawsuitEditModel()
            {
                Id = x.Id,FileNo=x.FileNo,                
                CourtsId = x.Courts.Id,
                Description = x.Description,
                Casetype = x.Casetype,
                Status = x.Status,
                ApplicationUserId=x.ApplicationUser.Id,
                HearingsList = (ICollection<HearingViewModel>)x.Hearings.Where(x => x.Lawsuits.Id == id).Select(e => new HearingViewModel()
                {
                    Id = e.Id,
                    Description = e.Description,
                    CreateOn = e.CreateOn
                }).ToList(),
                DoucmentList = (ICollection<DocumentViewModel>)x.Documents.Where(x => x.LawsuitId == id).Select(e => new DocumentViewModel()
                {
                 FileName=e.FileName,ContentType=e.ContentType,Id=e.Id
                }).ToList(),

                ApplicationUserList = (List<SelectListItem>)_context.ApplicationUsers.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                CourtList = (List<SelectListItem>)_context.Court.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CourtName }).ToList(),
                CustomersList = x.Customers.Where(x => x.Lawsuit.Id==id).ToList()

            }).FirstOrDefaultAsync();
                
            if (lawsuit == null)
            {
                return NotFound();
            }
            return View(lawsuit);
        }

        // POST: Lawsuits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FileNo,Description,CourtsId,CustomersId,ApplicationUserId,Status,Casetype,CreateOn")] LawsuitEditModel item)
        {
            var lawsuit=(dynamic)null;
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     lawsuit = new Lawsuit()
                    {
                        Id=item.Id,
                        Courts = _context.Court.Find(item.CourtsId),
                        FileNo = item.FileNo,
                       
                        Description = item.Description,
                        Casetype = item.Casetype,
                        Status = item.Status,
                        ApplicationUser = _context.ApplicationUsers.Find(item.ApplicationUserId),
                        CreateOn = DateTime.Today
                    };
                    _context.Update(lawsuit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LawsuitExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
                return RedirectToAction(nameof(Index));
            }
             lawsuit = await _context.Lawsuits.Where(x => x.Id == id).Select(x => new LawsuitEditModel()
            {
                Id = x.Id,
                FileNo = x.FileNo,
                
                CourtsId = x.Courts.Id,
                Description = x.Description,
                Casetype = x.Casetype,
                Status = x.Status,
                ApplicationUserId = x.ApplicationUser.Id,
                HearingsList = (ICollection<HearingViewModel>)x.Hearings.Where(x => x.Lawsuits.Id == id).Select(e => new HearingViewModel()
                {
                    Id = e.Id,
                    Description = e.Description,
                    CreateOn = e.CreateOn
                }).ToList(),
                ApplicationUserList = (List<SelectListItem>)_context.ApplicationUsers.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                CourtList = (List<SelectListItem>)_context.Court.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CourtName }).ToList(),
                //CustomersList = (List<SelectListItem>)_context.Customers.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.CustomerName }).ToList()


            }).FirstOrDefaultAsync();
            return View(lawsuit);
        }

        // GET: Lawsuits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawsuit = await _context.Lawsuits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawsuit == null)
            {
                return NotFound();
            }

            return View(lawsuit);
        }

        // POST: Lawsuits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lawsuit = await _context.Lawsuits.FindAsync(id);
            _context.Lawsuits.Remove(lawsuit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LawsuitExists(int id)
        {
            return _context.Lawsuits.Any(e => e.Id == id);
        }


        [HttpGet]
        public IActionResult AddHearing(int? Id)
        {
    
         
                var item = new HearingViewModel()
                {
                    Lawsuits=_context.Lawsuits.Find(Id),Description=""
                };
            return View(item);
          
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult AddHearing(int Id,  HearingViewModel item)
        {
            if(Id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var hearing = new Hearing()
                {
                    Description = item.Description,
                    Lawsuits = _context.Lawsuits.Find(item.Lawsuits.Id),
                    CreateOn=DateTime.Today
                };
                _context.Hearings.Add(hearing);
                _context.SaveChanges();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Edit", new { item.Lawsuits.Id}) });

            }
            else
            {

                return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddHearing", item) });
                
            }
            
        }

        public async Task<IActionResult> Documents(int? Id)
        {

            if (Id == null)
            {
                Id = 1;
            }
            var documents = await _context.Documents.Where(f => f.LawsuitId == Id).ToListAsync();
            return PartialView("_Documents", documents);
        }
        public IActionResult UploadFile()
        {
            return PartialView();
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
                        LawsuitId = 1,
                        Data = Content,
                        FileName = filename,
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

    }
}
