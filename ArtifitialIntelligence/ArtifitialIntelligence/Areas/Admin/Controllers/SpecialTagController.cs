using ArtifitialIntelligence.Data;
using ArtifitialIntelligence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Linq;
using System.Threading.Tasks;
namespace ArtifitialIntelligence.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Authorize]
    public class SpecialTagController : Controller
    {
        ApplicationDbContext _context;
        public SpecialTagController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.SpecialTag.ToList();
            return View(data);
        }
        //Get Action Method
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
            return View();
        }
        //Get Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SpecialTag specialTag)
        {
            if (ModelState.IsValid)
            {
                var SearchProduct = _context.SpecialTag.FirstOrDefault(c => c.SpecialTagName == specialTag.SpecialTagName);
                if (SearchProduct != null)
                {
                    ViewData["specialTagId"] = new SelectList(_context.SpecialTag.ToList(), "Id", "SpecialTagName");
                    ViewBag.message = "This Special Tag has already exist";
                    return View(specialTag);
                }
                _context.SpecialTag.Add(specialTag);
                await _context.SaveChangesAsync();
                TempData["add"] = "Special Tag Added Successfully";
                return RedirectToAction(nameof(Index));

            }

            return View(specialTag);
        }

        //Edit Get Action Method
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = _context.SpecialTag.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SpecialTag specialTag)
        {
            if (ModelState.IsValid)
            {
                _context.SpecialTag.Update(specialTag);
                await _context.SaveChangesAsync();
                TempData["edit"] = "Special Tag Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(specialTag);
        }

        //Details Get Action Method
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = _context.SpecialTag.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //Details Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(SpecialTag specialTage)
        {
            return RedirectToAction(nameof(Index));

        }

        //Delete Action Method
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = _context.SpecialTag.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }
            return View(specialTag);
        }
        //Delete Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, SpecialTag specialTag)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != specialTag.Id)
            {
                return NotFound();
            }
            var specialTags = _context.SpecialTag.Find(id);
            if (specialTags == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Remove(specialTags);
                await _context.SaveChangesAsync();
                TempData["done"] = "Special Tag Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

    }


}
