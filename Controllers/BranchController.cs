using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCTicketSystem.Models;
using SGCTicketSystem.ViewModels;
using System.Data.Entity.Infrastructure;


namespace SGCTicketSystem.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        SGCAppDbContext _context;

        public BranchController()
        {
            _context = new SGCAppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult NewBranch()
        {
            Branch branch = new Branch();
            return View("BranchForm", branch);
        }

        public ActionResult Index()
        {
            var dEpart = _context.Branches.ToList();
            return View(dEpart);
        }

        public ActionResult EditBranch(Int64 id)
        {
            var rec = _context.Branches.SingleOrDefault(c => c.BranchId == id);
            if (rec == null)
                return HttpNotFound();
            return View("BranchForm", rec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBranch(Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return View("Branch", branch);
            }
            if (branch.BranchId == 0)
            {
                Int64 vid = branch.BranchId;
                _context.Branches.Add(branch);
            }
            else
            {
                var IssueInDb = _context.Branches.Single(c => c.BranchId == branch.BranchId);
                IssueInDb.BranchName = branch.BranchName;
                IssueInDb.BranchAddress = branch.BranchAddress;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Branch");

        }


    }
}