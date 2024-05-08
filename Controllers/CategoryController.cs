using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCTicketSystem.Models;
using SGCTicketSystem.ViewModels;

namespace SGCTicketSystem.Controllers
{
    public class CategoryController : Controller
    {
        SGCAppDbContext _context;
        // GET: Category
        public CategoryController()
        {
            _context = new SGCAppDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var dEpart = _context.Categories.ToList();
            return View(dEpart);
        }

        public ActionResult NewCategeory()
        {
            Category category = new Category();
            return View("Category", category);
        }


        public ActionResult EditCategory(Int64 id)
        {
            var rec = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (rec == null)
                return HttpNotFound();
            return View("Category", rec);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCategory (Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("Category", category);
            }
            if (category.CategoryId == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var IssueInDb = _context.Categories.Single(c => c.CategoryId == category.CategoryId);
                IssueInDb.Description = category.Description;
             
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");

        }


        }
    }