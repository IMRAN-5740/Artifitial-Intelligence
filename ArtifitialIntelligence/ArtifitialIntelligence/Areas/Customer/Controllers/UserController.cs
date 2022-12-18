using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            var allUsers = _context.AplicationUsers.ToList();
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
            var user = _context.AplicationUsers.FirstOrDefault(c => c.Id == id);
            if(user==null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser userAppication)
        {
            var user = _context.AplicationUsers.FirstOrDefault(c => c.Id == userAppication.Id);
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
           var resultUSer= await _userManager.UpdateAsync(user);
            if(resultUSer.Succeeded)
            {
                TempData["Update"] = "User Data Has been Updated";
                return RedirectToAction(nameof(Index));
            }
            foreach(var error in resultUSer.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(user);
        }
    }
}
