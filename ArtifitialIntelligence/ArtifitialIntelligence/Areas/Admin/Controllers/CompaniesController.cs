using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtifitialIntelligence.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompaniesController : Controller
    {

       private ApplicationDbContext _context;
       private IHostingEnvironment _he;

 
        public CompaniesController(ApplicationDbContext context, IHostingEnvironment he)
        {
            _context = context;
            _he = he;
            
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
        public async Task<IActionResult> Create(Company company, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var SearchProduct = _context.Companies.FirstOrDefault(c => c.CompanyName == company.CompanyName);
                if (SearchProduct != null)
                {
                   
                    ViewBag.message = "This Company has already exist";
                    return View(company);
                }
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    var stream = new FileStream(name, FileMode.Create);
                    await image.CopyToAsync(stream);
                    company.ImageFileName = "Images/" + image.FileName;
                    stream.Close();
                }
                if (image == null)
                {
                    company.ImageFileName = "Images/No-Image.png";
                }
                if(company.canIncreaseLike==true)
                {
                    company.Like++;
                }

                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                TempData["Save"] = "New Company Added Successfully";
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
       
        public async Task<IActionResult> Edit(Company company,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));

                    string oldImage = Path.Combine(_he.WebRootPath + "/" + company.ImageFileName);

                    if (System.IO.File.Exists(oldImage) && company.ImageFileName != "Images/No-Image.png")
                    {
                        System.IO.File.Delete(oldImage);
                    }
                    var stream = new FileStream(name, FileMode.Create);
                    await image.CopyToAsync(stream);
                    company.ImageFileName = "Images/" + image.FileName;
                    stream.Close();
                }

                if (image == null)
                {

                    string oldImage = company.ImageFileName;

                    company.ImageFileName = oldImage;

                }
                _context.Companies.Update(company);
                await _context.SaveChangesAsync();
                TempData["Update"] = "Company Updated Successfully";
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
        
        public async Task<IActionResult> Delete(Company company, int? id,IFormFile image)
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
                if (image == null)
                {

                    string oldImage = Path.Combine(_he.WebRootPath + "/" + company.ImageFileName);

                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }

                }

                _context.Remove(companies);
                await _context.SaveChangesAsync();
               
                TempData["Delete"] = "Company Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(company);

        }

    }
}
