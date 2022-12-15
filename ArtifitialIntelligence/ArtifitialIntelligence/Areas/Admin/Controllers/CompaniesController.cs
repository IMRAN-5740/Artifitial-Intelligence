using ArtifitialIntelligence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ArtifitialIntelligence.Areas.Admin.Controllers
{
    public class CompaniesController : Controller
    {
        ApplicationDbContext _context;
        IHostingEnvironment _he;
        public CompaniesController(ApplicationDbContext context,IHostingEnvironment he)
        {
            _context = context;
            _he = he;

        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
