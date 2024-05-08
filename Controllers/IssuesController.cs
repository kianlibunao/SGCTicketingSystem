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
    public class IssuesController : Controller
    {
        SGCAppDbContext _context;
        private Int64 vNo;

        // GET: Issues
        public ActionResult Index()
        {
            var rec = _context.Issuess.Include(c => c.Status).Include(c => c.Category).Include(c => c.Priority).Include(c => c.Branch).Include(c => c.Department).ToList();
            return View("Index", rec);
        }
        public IssuesController()
        {
            _context = new SGCAppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewIssues()
        {
            Issues Issuess = new Issues();  
            var viewModel = new IssuesVsViewModel
            {
                Issuess = Issuess,
                Priorities = _context.Priorities.ToList(),
                Branches = _context.Branches.ToList(),
                Categories = _context.Categories.ToList(),
                Departments = _context.Departments.ToList(),
                Statuses = _context.Statuses.ToList()
            };
            return View("Issues", viewModel);
        }

        public ActionResult SendedTicket()
        {
            TicketPass();
            return View("Sended");
        }
       
        //public ActionResult Issues(Int64 id)
        //{
        //    var issue = _context.Issuess.SingleOrDefault(c => c.IssuesId == id);
        //    if (issue.StatusId > 1)
        //        return Content("this technical has been viewed this issue already");
        //    return View("Index");
        //}




        public ActionResult UpdateIssue (Int64 id)
        {
            var rec = _context.Issuess.Where(c => c.IssuesId == id).FirstOrDefault();
            return View(rec);
        }

        public ActionResult UpdateIssue(Issues model)
        {
            var rec = _context.Issuess.Where(c => c.IssuesId == model.IssuesId).FirstOrDefault();
            if (rec != null)
            {
                rec.Title = model.Title;
                rec. AssignedTo = model.AssignedTo;
                rec.OpenedBy = model.OpenedBy;
                rec.OpenedDate = model.OpenedDate;
                rec.Department = model.Department;
                rec.Status = model.Status;
                rec.Category = model.Category;
                rec.Priority = model.Priority;
                rec.Branch = model.Branch;
                rec.Description = model.Description;
                rec.DueDate = model.DueDate;
                rec.RelatedIssues = model.RelatedIssues;
                rec.Comments = model.Comments;
                    
            }
            return RedirectToAction("index");
        }


        //public ActionResult EditIssues(Int64 id)
        //{
        //    var rec = _context.Issuess.SingleOrDefault(c => c.IssuesId == id);
        //    if (rec == null)
        //        return HttpNotFound();
        //    var viewModel = new IssuesVsViewModel
        //    {
        //        Issuess = rec,
        //        Priorities = _context.Priorities.ToList(),
        //        Branches = _context.Branches.ToList(),
        //        Categories = _context.Categories.ToList(),
        //        Departments = _context.Departments.ToList(),
        //        Statuses = _context.Statuses.ToList()
        //    };
        //    return View("Issues", viewModel);
        //}
  
        private string GetUserName(Int64 userId)
        {
            var rec = _context.Users.Single(c => c.UserId == userId);
            string name = rec.Username;
            return name;
        }
        private Int64 TicketPass()
        {
            var rec = _context.Tickets.SingleOrDefault();
             vNo = rec.Ticketnn;
            ViewBag.viewbag = "Your Ticket No. is: " + vNo;
            _context.SaveChanges();
            return vNo + 1;
        }

        public ActionResult SaveIssues (IssuesVsViewModel issues) 
        {
            if (!ModelState.IsValid)
            {   
                var viewModel = new IssuesVsViewModel
                {
                    Issuess = issues.Issuess,
                    Priorities = _context.Priorities.ToList(),
                    Branches = _context.Branches.ToList(),
                    Categories = _context.Categories.ToList(),
                    Departments = _context.Departments.ToList(),
                    Statuses = _context.Statuses.ToList()
                   //
                };
                return View("Sended", viewModel);
            }
            if (issues.Issuess.IssuesId == 0)
            {
                vNo = TicketPass();
                Issues vIssue = new Issues();
                vIssue.AssignedTo = issues.Issuess.AssignedTo;
                vIssue.BranchId = issues.Issuess.BranchId;
                vIssue.CategoryId = issues.Issuess.CategoryId;
                vIssue.DepartmentId = issues.Issuess.DepartmentId;
                vIssue.Description = issues.Issuess.Description;
                vIssue.Comments = issues.Issuess.Comments;
                vIssue.PriorityId = issues.Issuess.PriorityId;
                vIssue.TickentNn = vNo;
                vIssue.OpenedBy = issues.Issuess.OpenedBy;
                vIssue.OpenedDate = issues.Issuess.OpenedDate;
                vIssue.StatusId = issues.Issuess.StatusId;
                var tick = _context.Tickets.SingleOrDefault();
                tick.Ticketnn = vNo;
                _context.Issuess.Add(vIssue);
                _context.SaveChanges();
                return RedirectToAction("SendedTicket" , vNo);
            }
            else
            {
                var IssueInDb = _context.Issuess.Single(c => c.IssuesId == issues.Issuess.IssuesId);
                IssueInDb.Title = issues.Issuess.Title;
                IssueInDb.Description = issues.Issuess.Description;
                IssueInDb.Comments = issues.Issuess.Comments;
                IssueInDb.StatusId = issues.Issuess.StatusId;
                IssueInDb.CategoryId = issues.Issuess.CategoryId; 
                IssueInDb.DepartmentId = issues.Issuess.DepartmentId;
                IssueInDb.BranchId = issues.Issuess.BranchId;
                IssueInDb.PriorityId = issues.Issuess.PriorityId;
                IssueInDb.OpenedBy = issues.Issuess.OpenedBy;
                IssueInDb.OpenedDate = issues.Issuess.OpenedDate;
                IssueInDb.AssignedTo = issues.Issuess.AssignedTo;
                IssueInDb.Status = issues.Issuess.Status;
                IssueInDb.Category = issues.Issuess.Category;
                IssueInDb.TickentNn = issues.Issuess.TickentNn;
                _context.SaveChanges();
            }                                 
            return RedirectToAction("Sended", "Issues" );
        }
    }
}