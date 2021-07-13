using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using congr.Data;
using congr.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace congr.Controllers
{
    public class NewBirthdayController : Controller
    {
        private readonly congrContext _context;
        IWebHostEnvironment _appEnvironment;

        public NewBirthdayController(congrContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Birthdays
        public IActionResult Index()
        {
            return View();
        }

        // GET: Birthdays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthday = await _context.Birthday
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birthday == null)
            {
                return NotFound();
            }

            return View(birthday);
        }

        // GET: Birthdays/Create
        public async Task<IActionResult> Create()
        {
            return View(await _context.Birthday.ToListAsync());
        }

        // POST: Birthdays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Fio, date")] Birthday birthday, IFormFile Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string path = "/files/" + Photo.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await Photo.CopyToAsync(fileStream);
                    }
                    birthday.Photo = path;
                }
                _context.Add(birthday);
                await _context.SaveChangesAsync();
                return Redirect("/Home/Index");
            }
            return View(birthday);
        }

        // GET: Birthdays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthday = await _context.Birthday.FindAsync(id);
            if (birthday == null)
            {
                return NotFound();
            }
            return View(birthday);
        }

        // POST: Birthdays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fio, Photo, date")] Birthday birthday, IFormFile newPhoto)
        {
            
            if (id != birthday.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (newPhoto != null)
                {
                    string path = "/files/" + newPhoto.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await newPhoto.CopyToAsync(fileStream);
                    }
                    birthday.Photo = path;
                }
                try
                {
                    _context.Update(birthday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirthdayExists(birthday.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Home/Index");
            }
            return View(birthday);
        }

        // GET: Birthdays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthday = await _context.Birthday
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birthday == null)
            {
                return NotFound();
            }

            return View(birthday);
        }

        // POST: Birthdays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var birthday = await _context.Birthday.FindAsync(id);
            _context.Birthday.Remove(birthday);
            await _context.SaveChangesAsync();
            return Redirect("/Home/Index");
        }

        private bool BirthdayExists(int id)
        {
            return _context.Birthday.Any(e => e.Id == id);
        }
    }
}
