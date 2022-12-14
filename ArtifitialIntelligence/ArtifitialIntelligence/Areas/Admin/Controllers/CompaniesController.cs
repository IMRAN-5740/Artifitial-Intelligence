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
    }
}
