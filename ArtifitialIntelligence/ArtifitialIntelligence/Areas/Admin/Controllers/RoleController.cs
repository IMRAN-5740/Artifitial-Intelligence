using ArtifitialIntelligence.Areas.Admin.Models;
using ArtifitialIntelligence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArtifitialIntelligence.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {

        Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
        ApplicationDbContext _context;
        public RoleController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            IdentityRole role = new IdentityRole();
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist == false)
            {
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["save"] = "Role Has Been Saved Successfully ";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.message = "This Role Name is Already Exist..";
                ViewBag.name = name;
                return View();
            }

            return View();
        }


        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.mgs = "This role Name is already exist Please Try Another";
                ViewBag.name = name;
                return View();
            }
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["edit"] = "Role Name has been Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["done"] = "Role Name has been Deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Assign()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers.Where(c => c.LockoutEnd < DateTime.Now || c.LockoutEnd == null).ToList(), "Id", "UserName");
            ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(RoleUserVm roleUserVm)
        {
            var userInfo = _context.ApplicationUsers.FirstOrDefault(c => c.Id == roleUserVm.UserId);
            bool Check = await _userManager.IsInRoleAsync(userInfo, roleUserVm.RoleId);
            if (Check)
            {
                ViewBag.message = "This User Role Has already assigned  Please Try another";

                //TempData["done"] = "In this User Role Has Already Assigned";
                //return RedirectToAction(nameof(Assign));
                ViewData["UserId"] = new SelectList(_context.ApplicationUsers.Where(c => c.LockoutEnd < DateTime.Now || c.LockoutEnd == null).ToList(), "Id", "UserName");
                ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                return View();

            }
            else
            {
                var roleInfo = await _userManager.AddToRoleAsync(userInfo, roleUserVm.RoleId);
                if (roleInfo.Succeeded)
                {
                    TempData["save"] = "User Role Has Been Assign Successfully";
                    return RedirectToAction(nameof(Assign));
                }
            }
            return View();
        }


        public ActionResult AssignUserRole()
        {
            var result = from ur in _context.UserRoles
                         join r in _context.Roles on ur.RoleId equals r.Id
                         join ap in _context.ApplicationUsers on ur.UserId equals ap.Id
                         select new UserRoleMapping()
                         {
                             UserId = ur.UserId,
                             RoleId = ur.RoleId,
                             UserName = ap.UserName,
                             RoleName = r.Name
                         };
            ViewBag.UserRoles = result;
            return View();
        }
    }
}
