using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diary.UI.DataContext;
using Diary.UI.Models;

namespace Diary.UI.Controllers
{
    public class SMSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SMSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SMS
        public  IActionResult Index()
        {
            var item =  _context.Recipient.Select(SMSViewModel.ViewModel);
            return View(item.ToList());
        }

        // GET: SMS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var messagerecipient = await _context.Recipient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (messagerecipient == null)
            {
                return NotFound();
            }

            return View(messagerecipient);
        }

        // GET: SMS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SMS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lawsuit,PhoneNo,Message,IsSend,IsRead")] Messagerecipient messagerecipient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messagerecipient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(messagerecipient);
        }

       
        
    }
}
