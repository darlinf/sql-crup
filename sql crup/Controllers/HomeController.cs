using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sql_crup.DbContext;
using sql_crup.Models;

namespace sql_crup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContext _db ;

        public HomeController(ILogger<HomeController> logger, IContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var resurt = _db.Get();
            return View(resurt);
        }

        public IActionResult Delete(int? id)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult PersonCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersoCreate([Bind("LastName,FirstName,Address,City")] Persons persons)
        {
            _db.Insert(persons);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var resurt = _db.GetById(id);
            resurt.PersonID = id;
            return View(resurt);
        }
        
        [HttpPost]
        public IActionResult Edited([Bind("LastName,FirstName,Address,City,PersonID")] Persons persons)
        {
            _db.Update(persons, persons.PersonID);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
