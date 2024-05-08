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
    public class DepartmentController : Controller
    {
        SGCAppDbContext _context;
        // GET: Department
        public DepartmentController()
        {
            _context = new SGCAppDbContext();
        }

        public ActionResult Index()
        {
            var dEpart = _context.Departments.ToList();
            return View(dEpart);
        }
        public ActionResult NewDepartment()
        {
            Department department = new Department();
            return View("DepartmentForm", department);
        }

        public ActionResult EditDepartment(Int64 id)
        {
            var rec = _context.Departments.SingleOrDefault(c => c.Departmentid == id);

            if (rec == null)
                return HttpNotFound();

            return View("DepartmentForm", rec);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("Department", department);
            }

            if (department.Departmentid == 0)
            {
                _context.Departments.Add(department);
            }
            else
            {
                var IssueInDb = _context.Departments.Single(c => c.Departmentid == department.Departmentid);
                IssueInDb.DepartmentName = department.DepartmentName;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Department");

        }





    }
}