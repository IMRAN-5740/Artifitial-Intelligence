using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArtifitialIntelligence.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserController : Controller
    {

        UserManager<IdentityUser> _userManager;
        ApplicationDbContext _context;
        public UserController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context=context;
        }

        public IActionResult Index()
        {
            var allUsers = _context.ApplicationUsers.ToList();
            return View(allUsers);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if(ModelState.IsValid)
            {
                var userResult = await _userManager.CreateAsync(user, user.PasswordHash);
                if (userResult.Succeeded)
                {
                    TempData["Save"] = "Registration Successfull";
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in userResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            return View();
        }


        public async Task<IActionResult> Edit(string id)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(c => c.Id == id);
            if(user==null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser userAppication)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(c => c.Id == userAppication.Id);
            if (user == null)
            {
                return NotFound();
            }
            if(userAppication == null)
            {
                return NotFound();
            }
            if(user.Id != userAppication.Id)
            {
                return NotFound();
            }
            user.FirstName = userAppication.FirstName;
            user.MiddleName = userAppication.MiddleName;
            user.LastName= userAppication.LastName;
           var resultUser= await _userManager.UpdateAsync(user);
            if(resultUser.Succeeded)
            {
                TempData["Update"] = "User Data Has been Updated";
                return RedirectToAction(nameof(Index));
            }
            foreach(var error in resultUser.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(user);
        }


        public async Task<IActionResult> Details(string id)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> LockOut(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Info = _context.ApplicationUsers.FirstOrDefault(c => c.Id == id);
            if (Info == null)
            {
                return NotFound();
            }
            return View(Info);
        }

        [HttpPost]

        public async Task<IActionResult> LockOut(ApplicationUser applicationUser)
        {
            var userInfo = _context.ApplicationUsers.FirstOrDefault(c => c.Id == applicationUser.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.LockoutEnd = DateTime.Now.AddDays(15);
            int rowAffected = _context.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["lock"] = "User Has Been LockOut Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(userInfo);
        }

        public async Task<IActionResult> Active(string id)
        {
            var UserInfo = _context.ApplicationUsers.FirstOrDefault(c => c.Id == id);
            if (id == null)
            {
                return NotFound();
            }
            if (UserInfo == null)
            {
                return NotFound();
            }

            return View(UserInfo);
        }

        [HttpPost]

        public async Task<IActionResult> Active(ApplicationUser applicationUser)
        {
            var userInfo = _context.ApplicationUsers.FirstOrDefault(c => c.Id == applicationUser.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.LockoutEnd = null;
            // userInfo.LockoutEnd = DateTime.Now.AddDays(-1);
            int rowAffected = _context.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["lockEdit"] = "User Has Been Unlocked Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {

            var user = _context.ApplicationUsers.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser userApplication)
        {
            if(ModelState.IsValid)
            {
                var user =  _context.ApplicationUsers.FirstOrDefault(c => c.Id == userApplication.Id);
                if (user ==null)
                {
                    return NotFound();
                }
                if (userApplication.Id != user.Id)
                {
                    return NotFound();
                }
                if (userApplication == null)
                {
                    return NotFound();
                }


                var userResult = await _userManager.DeleteAsync(user);
                if(userResult.Succeeded)
                {
                    TempData["Delete"] = "User has been Deleted Successfully";
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in userResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            
            return View();
        }
    }
}
