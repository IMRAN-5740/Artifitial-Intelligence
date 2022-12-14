using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ArtifitialIntelligence.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompaniesController : Controller
    {

        ApplicationDbContext _context;
        public CompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var companies = _context.Companies.ToList();
            return View(companies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if(ModelState.IsValid)
            {
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        [HttpGet]
        public ActionResult Edit(int ? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var companies = _context.Companies.Find(id);
            if(companies==null)
            {
                return NotFound();
            }

            return View(companies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Companies.Update(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);

        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var companies = _context.Companies.Find(id);
            if (companies == null)
            {
                return NotFound();
            }

            return View(companies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Details(Company company)
        {
             return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var companies = _context.Companies.Find(id);
            if (companies == null)
            {
                return NotFound();
            }

            return View(companies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id,Company company)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(id!=company.Id)
            {
                return NotFound();
            }
            var companies = _context.Companies.Find(id);
            if(companies==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Companies.Remove(companies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);

        }

    }
}
