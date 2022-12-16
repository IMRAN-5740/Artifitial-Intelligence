using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ArtifitialIntelligence.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CompaniesController : Controller
    {
        private ApplicationDbContext _context;
        private IWebHostEnvironment _he;

        [System.Obsolete]
        public CompaniesController(ApplicationDbContext context,IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }
        public IActionResult Index()
        {
            var data = _context.Companies.ToList();
            return View(data);
        }

        // Index Post Action Method
        //[HttpPost]
        //public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        //{
        //    var products = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).Where(x => x.Price >= lowAmount && x.Price <= largeAmount).ToList();
        //    if (lowAmount == null || largeAmount == null)
        //    {
        //        products = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).ToList();
        //    }
        //    return View(products);
        //}

        // Create Get Method
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //Create Post Action Method
        [HttpPost]
        public async Task<ActionResult> Create(Company company, IFormFile image)
        {

            if (ModelState.IsValid)
            {
                var SearchProduct = _context.Companies.FirstOrDefault(c => c.CompanyName == company.CompanyName);
                if (SearchProduct != null)
                {

                    ViewBag.message = "This Product has already exist";
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

                if(company.CanIncreaseLike==true)
                {
                    company.Like++;
                }

                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
                TempData["add"] = "New Product Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        //Edit Get Action Method
        [HttpGet]
        public ActionResult Edit(int? id)
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

        //Edit Post Action Method
        [HttpPost]
        public async Task<ActionResult> Edit(Company company, IFormFile image)
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
                if(company.CanIncreaseLike==false && company.Like>0)
                {
                    company.Like--;
                }
                if(company.CanIncreaseLike==true)
                {
                    company.Like++;
                }
                _context.Companies.Update(company);
                await _context.SaveChangesAsync();
                TempData["Update"] = "Company Updated Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        //Get Details Action Method
        [HttpGet]
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

     //   Get Delete Action Method
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Companies.FirstOrDefault(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        //Post Delete Action Methd
        [HttpPost]
        public async Task<ActionResult> Delete(Company company, int? id, IFormFile image)
        {

            if (id == null)
            {
                return NotFound();
            }
            if (id != company.Id)
            {
                return NotFound();
            }

            var comapanyFind = _context.Companies.Find(id);
            if (comapanyFind == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                if (image == null)
                {

                    string oldImage = Path.Combine(_he.WebRootPath + "/" + comapanyFind.ImageFileName);

                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }

                }

                _context.Remove(comapanyFind);
                await _context.SaveChangesAsync();
                TempData["Delete"] = "Company Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(comapanyFind);
        }
    }
    
}

