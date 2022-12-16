using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ArtifitialIntelligence.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {

        ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            var companies=_context.Companies.ToList();
            return View(companies);
        }



        //Get Product Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        //Post Product Details Action in Session Method
        [HttpPost]
        [ActionName("Details")]
        public ActionResult ProductDetails(int? id)
        {
            List<Company> companies = new List<Company>();
            if (id == null)
            {
                return NotFound();
            }
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            companies = HttpContext.Session.Get<List<Company>>("companies");
            if (companies == null)
            {
                companies = new List<Company>();
            }
            companies.Add(company);
            HttpContext.Session.Set("companies", companies);
            //return View(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
