using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtifitialIntelligence.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.Emit;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Index( int? page)
        {
            var mySortedList = _context.Companies.OfType<Company>().OrderByDescending(x => x.Like).ToList()/*.ToPagedList(page??1,3)*/;
            _context.Companies.AddRange(mySortedList.ToArray());
           // var companies=_context.Companies.ToList();
            return View(mySortedList);
        }
        //Post Index Method
        [HttpPost]
        [ActionName("Index")]
        [Authorize]
     public IActionResult CompanyIndex(int? id)
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

           // Company aCompany = new Company();
            if(id!=null)
            {
                company.Like+=1;
               // return View(company);
            }
            // HttpContext.Session.Set("aCompany", aCompany);
            // //return View(product);

            //  _context.Companies.Add(company);
            var companies = _context.Companies.ToList();
            _context.SaveChangesAsync();
           // return View(companies);
            return RedirectToAction(nameof(Index));
        }


        //Get Product Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            if(company==null)
            {
                return NotFound();
            }
           
            return View(company);
        }
        //Post Product Details Action in Session Method
        [HttpPost]
        [ActionName("Details")]
        public ActionResult CompanyDetails(int? id)
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

        public ActionResult ProductIndex(int? id)
        {
            List<Products> listOfProduct = new List<Products>();
            listOfProduct = (from pro in _context.Products
                             where pro.CompanyId == id
                             select new Products()
                             {
                               
                                 
                                 Id= pro.Id,
                                 CompanyId= pro.CompanyId,
                                 Name = pro.Name,
                                 Price = pro.Price,
                                 Image= pro.Image,
                                 ProductColor= pro.ProductColor,
                                 IsAvailable= pro.IsAvailable,
                                 SpecialTag= pro.SpecialTag,
                                 ProductTypeId= pro.ProductTypeId,

                             }).ToList();
            ViewBag.Id = id;
            return View(listOfProduct);
            
        }
        [HttpGet]
        public ActionResult ProductDetails(int? id)
        {
            ViewData["companyId"] = new SelectList(_context.Companies.ToList(), "Id", "CompanyName");
            ViewData["productTypeId"] = new SelectList(_context.ProductTypes.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        //Post Product Details Action in Session Method
        [HttpPost]
        [Authorize]
        [ActionName("ProductDetails")]
        public ActionResult ProductDetailsWithCart(int? id)
        {
            List<Products> products = new List<Products>();
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products = HttpContext.Session.Get<List<Products>>("products");
            if (products == null)
            {
                products = new List<Products>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);
            //return View(product);
            return RedirectToAction("ProductIndex",new {id=product.CompanyId});
        }
        public ActionResult ShowComment(int? id)
        {
            List<Comment> listOfComment = new List<Comment>();
            listOfComment = (from comment in _context.Comments
                             where comment.ProductId== id
                             select new Comment()
                             {
                                 ProductId = comment.ProductId,
                                 CommentId = comment.CommentId,
                                 CommentDescription = comment.CommentDescription,
                                 Rating = comment.Rating,
                                 CommentedOn = comment.CommentedOn

                             }).ToList();
            ViewBag.ProductId = id;
            return View(listOfComment);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(int id, int rating, string productComment)
        {
            Comment listComment = new Comment();
            listComment.ProductId = id;
            listComment.Rating = rating;
            listComment.CommentDescription = productComment;
            listComment.CommentedOn = DateTime.Now;
            listComment.Rating = rating;
            listComment.GuestId = Guid.NewGuid();
            _context.Comments.Add(listComment);
            _context.SaveChanges();

            return RedirectToAction("ShowComment", new { id = id });

            // return View();
        }
        //Get Cart Remove Method

        [ActionName("Remove")]
        public IActionResult RemoveFromCart(int? id)
        {
            List<Products> products = new List<Products>();
            products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int? id)
        {
            List<Products> products = new List<Products>();
            products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //Get Product Cart Action Method
        public IActionResult Cart()
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products == null)
            {
                products = new List<Products>();
            }
            return View(products);
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
