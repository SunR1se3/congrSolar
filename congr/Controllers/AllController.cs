using congr.Data;
using congr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace congr.Controllers
{
    public class AllController : Controller
    {
        private readonly congrContext _context;

        public AllController(congrContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Birthday> all = await _context.Birthday.ToListAsync();
            IEnumerable currentMonth_items = all.Where(s => s.date.Month == DateTime.Now.Month);
            return View(currentMonth_items);
        }

        public async Task<IActionResult> NextMonth()
        {
            List<Birthday> all = await _context.Birthday.ToListAsync();
            IEnumerable nextMonth_items = all.Where(s => s.date.Month == DateTime.Now.Month+1);
            return View(nextMonth_items);
        }

        public async Task<IActionResult> Year()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //ViewBag.Months = CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames.ToArray();
            ViewBag.Months = new[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            return View(await _context.Birthday.ToListAsync());
        }

    }
}
