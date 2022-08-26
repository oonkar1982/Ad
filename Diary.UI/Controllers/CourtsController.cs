using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diary.UI.DataContext;
using Diary.UI.Models;
using Diary.UI.Rep;
using Microsoft.AspNetCore.Authorization;

namespace Diary.UI.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class CourtsController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public CourtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Court.ToListAsync());
        }

     

        // GET: Courts/Create
        public IActionResult Create()
        {
            CourtRep rep = new CourtRep(_context);

            var model = rep.GetCourtInputModel(0);
           
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourtInputModel item)
        {
            CourtRep rep = new CourtRep(_context);
            if (ModelState.IsValid)
            {
                var i = await rep.Create(item);
                return RedirectToAction(nameof(Index));
            }
            var model = new CourtInputModel()
            {
                CityId=item.CityId,StateId=item.StateId,CourtTypeId=item.CourtTypeId,
                StateList = (List<SelectListItem>)_context.States.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.StateName }).ToList(),
                CityList = (List<SelectListItem>)_context.Cities.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                CourtType = (List<SelectListItem>)_context.StringMap.Where(x => x.FiledName.Equals("CourtType")).Select(e => new SelectListItem { Value = e.DisplayCode.ToString(), Text = e.DisplayName }).ToList()
            };
            return View(model);
        }

        // GET: Courts/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            
            CourtRep rep = new CourtRep(_context);
            var court = await rep.GetCourtInputModel(Id);
            if (court == null)
            {
                return NotFound();
            }
            return View(court);
        }

        // POST: Courts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourtInputModel court)
        {
            CourtRep rep = new CourtRep(_context);
            if (id != court.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                var message = await rep.Edit(id, court);                
                return RedirectToAction(nameof(Index));
            }
            return View(court);
        }

    }
}
