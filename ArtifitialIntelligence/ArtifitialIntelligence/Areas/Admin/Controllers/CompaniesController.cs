using Microsoft.AspNetCore.Mvc;

namespace ArtifitialIntelligence.Areas.Admin.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
