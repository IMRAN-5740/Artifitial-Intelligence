using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using ArtifitialIntelligence.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ArtifitialIntelligence.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderController : Controller
    {
        ApplicationDbContext _context;
        public OrderController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            //var product = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).ToList().ToPagedList(page ?? 1, 6);
            var orderList = _context.Orders.OrderByDescending(c=> c.OrderNo).ToPagedList(1,6);
            return View(orderList);
           // return View();
        }
        //Get CheckOut Action Method
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
        //Post CheckOut Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(Order anOrder)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");

            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.Id;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }
            anOrder.OrderNo = GetOrderNumber();
            
            _context.Orders.Add(anOrder);
            await _context.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Products>());
            // TempData["status"] = "Success";
            TempData["ok"] = "Order Placed/Confirmed has been Successfully";
            TempData["message"] = "Order has been confirmed we've also sent an email for confirmetion.It will be delivered soon Thank you";
            return RedirectToAction(nameof(Index));
           // return View();
        }

        public string GetOrderNumber()
        {
            int rowCount = _context.Orders.ToList().Count()+1;
            //rowCount=rowCount+1;
            return rowCount.ToString("000");
        }
       
    }
}
