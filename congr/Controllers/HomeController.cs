using congr.Data;
using congr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace congr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly congrContext _context;

        public HomeController(ILogger<HomeController> logger, congrContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.afterThreeDays = _context.Birthday.Where(s => s.date.Day <= DateTime.Now.Day + 3 && s.date.Month == DateTime.Now.Month).ToList();
            ViewBag.afterSevenDays = _context.Birthday.Where(s => s.date.Day <= DateTime.Now.Day + 7 && s.date.Month == DateTime.Now.Month).ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
