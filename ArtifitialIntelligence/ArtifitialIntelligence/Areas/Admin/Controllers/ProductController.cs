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
    [Authorize]
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IHostingEnvironment _he;

       
        public ProductController (ApplicationDbContext context,IHostingEnvironment he)
        {
            _context = context;
            _he = he;   
        }
        public IActionResult Index()
        {
            var data = _context.Products.Include(c=>c.ProductTypes).Include(f=>f.SpecialTag).Include(c=>c.Companies).ToList();
            return View(data);
        }

        // Index Post Action Method
        [HttpPost]
        public IActionResult Index(decimal ?lowAmount,decimal ?largeAmount)
        {
            var products = _context.Products.Include(c=>c.ProductTypes).Include(c=>c.SpecialTag).Where(x=>x.Price>=lowAmount && x.Price<=largeAmount).ToList();
            if(lowAmount==null || largeAmount==null)
            {
                products = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).ToList();
            }
            return View(products);
        }
        // Create Get Method
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["productTypeId"] = new SelectList(_context.ProductTypes.ToList(),"Id","ProductType");
            ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
            ViewData["companyId"] = new SelectList(_context.Companies.ToList(), "Id", "CompanyName");
            //< td > @Html.DropDownListFor(c => c.DepartmentId, new SelectList(ViewBag.Department, "Id", "DeptShortName"), "....Select....", new { @class = "form-control" }) </ td >
            return View();
        }


        //Create Post Action Method
        [HttpPost]
        public async Task<ActionResult> Create(Products products,IFormFile image)
        {

            if(ModelState.IsValid)
            {
                var SearchProduct = _context.Products.FirstOrDefault(c => c.Name == products.Name);
                if(SearchProduct != null)
                {
                    ViewData["companyId"] = new SelectList(_context.Companies.ToList(), "Id", "CompanyName");
                    ViewData["productTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
                    ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
                    ViewBag.message = "This Product has already exist";
                    return View(products);
                }
                if(image!= null)
                {
                    var name = Path.Combine(_he.WebRootPath+ "/ProductImages", Path.GetFileName(image.FileName));
                    var stream = new FileStream(name, FileMode.Create);
                    await image.CopyToAsync(stream);
                    products.Image = "ProductImages/" + image.FileName;
                    stream.Close();
                }
                if(image==null)
                {
                    products.Image = "ProductImages/No-Image.png";
                }

                _context.Products.Add(products);
                await _context.SaveChangesAsync();
                TempData["add"] = "New Product Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        //GET Edit Method
        [HttpGet]
        public ActionResult Edit(int ?id)
        {
            ViewData["companyId"] = new SelectList(_context.Companies.ToList(), "Id", "CompanyName");
            ViewData["productTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
            if(id==null)
            {
                return NotFound();
            }
            var product=_context.Products.Include(c => c.ProductTypes).Include(f => f.SpecialTag).FirstOrDefault(c => c.Id == id);
            if(product==null)
            {
                return NotFound();
            }

            return View(product);
        }

        //Edit Post Action Method
        [HttpPost]
        public async Task<ActionResult> Edit(Products products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/ProductImages", Path.GetFileName(image.FileName));
 
                    string oldImage = Path.Combine(_he.WebRootPath +"/"+ products.Image); 
                   
                    if(System.IO.File.Exists(oldImage) && products.Image!= "ProductImages/No-Image.png")
                    {
                        System.IO.File.Delete(oldImage);
                    }
                    var stream = new FileStream(name, FileMode.Create);
                    await image.CopyToAsync(stream);
                    products.Image = "ProductImages/" + image.FileName;
                    stream.Close();
                }
               
                if (image==null)
                {
                    
                    string oldImage =  products.Image;
                    
                    products.Image = oldImage;
                   
                }
                _context.Products.Update(products);
                await _context.SaveChangesAsync();
                TempData["edit"] = "Product Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            
            return View(products);
        }

        //Get Details Action Method
        [HttpGet]
        public ActionResult Details(int ?id)
        {
            ViewData["companyId"] = new SelectList(_context.Companies.ToList(), "Id", "CompanyName");
            ViewData["productTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
            if (id == null)
            {
                return NotFound();
            }
            var product=_context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).FirstOrDefault(c=>c.Id==id);
            if(product==null)
            {
                return NotFound();
            }
            return View(product);
        }

        //Get Delete Action Method
        [HttpGet]
        public ActionResult Delete(int ?id )
        {
            ViewData["companyId"] = new SelectList(_context.Companies.ToList(), "Id", "CompanyName");
            ViewData["productTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
            if (id==null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).FirstOrDefault(c => c.Id == id);
            //var productImage = _context.Products.FirstOrDefault(c => c.Id == products.Id);
            
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }


        //Post Action Methd
        [HttpPost]
        public async Task<ActionResult> Delete(Products products, int? id, IFormFile image)
        {

            if (id == null)
            {
                return NotFound();
            }
            if (id != products.Id)
            {
                return NotFound();
            }
            
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();                                                                                            
            }

            
            if (ModelState.IsValid)
            {

                if (image == null)
                {
                    
                    string oldImage = Path.Combine(_he.WebRootPath + "/" + product.Image);

                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                   
                }

                _context.Remove(product);
                await _context.SaveChangesAsync();
                TempData["done"] = "Product Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }



 

    }
}
