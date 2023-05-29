﻿using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using ArtifitialIntelligence.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            //var product = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).ToList().ToPagedList(page ?? 1, 6);
           if(id== null)
            {
                var orderList = _context.Orders.OrderByDescending(c => c.OrderNo).ToPagedList(1, 6);
                return View(orderList);
            }
           else
            {
                List<Products> listOfProduct = new List<Products>();
                listOfProduct = (from pro in _context.OrderDetails
                                 where pro.OrderId == id
                                 select new Products()
                                 {

                                     Name = pro.Products.Name,
                                     Image= pro.Products.Image,
                                     Price=pro.Products.Price

                                 }).ToList();

                ViewBag.ProductDetails = listOfProduct;
                decimal sumTotal = 0;
                foreach(var data in listOfProduct)
                {
                    sumTotal = sumTotal + data.Price;
                }
                ViewBag.ProductSum=sumTotal;
                var orderList = _context.Orders.OrderByDescending(c => c.OrderNo).ToPagedList(1, 6);
                return View(orderList);
            }
            
            // return View();
        }
        [HttpGet]
        public IActionResult OrderProductIndex(int id)
        {
            //var product = _context.Products.Include(c => c.ProductTypes).Include(c => c.SpecialTag).ToList().ToPagedList(page ?? 1, 6);
            List<Products> listOfProduct = new List<Products>();
            listOfProduct = (from pro in _context.OrderDetails
                             where pro.OrderId == id
                             select new Products()
                             {
                                 
                                 Name=pro.Products.Name

                             }).ToList();
                ViewBag.ProductDetails = listOfProduct;
           return View(listOfProduct);

             
        }




        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var checkOrder=_context.Orders.FirstOrDefault(check=>check.Id== id);
            if(checkOrder==null)
            {
                return NotFound();
            }

            return View(checkOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            var orderStatus = _context.Orders.FirstOrDefault(c => c.Id == order.Id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            if (order == null)
            {
                return NotFound();
            }
            if (orderStatus.Id != order.Id)
            {
                return NotFound();
            }
            orderStatus.Name = order.Name;
            orderStatus.PhoneNo = order.PhoneNo;
            orderStatus.Email = order.Email;
            orderStatus.Address = order.Address;
            orderStatus.OrderDate = order.OrderDate;


           _context.Orders.Update(orderStatus);
            await _context.SaveChangesAsync();
            TempData["edit"] = "Order Info Updated Successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var checkOrder = _context.Orders.FirstOrDefault(check => check.Id == id);
            if (checkOrder == null)
            {
                return NotFound();
            }

            return View(checkOrder);
        }
        

        [HttpGet]
        public IActionResult Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var checkOrder = _context.Orders.FirstOrDefault(check => check.Id == id);
            if (checkOrder == null)
            {
                return NotFound();
            }

            return View(checkOrder);
        }

        public async Task<IActionResult> Delete(Order order)
        {
            var orderStatus = _context.Orders.FirstOrDefault(c => c.Id == order.Id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            if (order == null)
            {
                return NotFound();
            }
            if (orderStatus.Id != order.Id)
            {
                return NotFound();
            }
            //orderStatus.Name = order.Name;
            //orderStatus.PhoneNo = order.PhoneNo;
            //orderStatus.Email = order.Email;
            //orderStatus.Address = order.Address;
            //orderStatus.OrderDate = order.OrderDate;


            _context.Orders.Remove(orderStatus);
            await _context.SaveChangesAsync();
            TempData["done"] = "Order has been Deleted Successfully";
            return RedirectToAction(nameof(Index));
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
