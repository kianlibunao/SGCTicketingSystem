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
    public class TechnicalController : Controller
    {
        // GET: Technical
        SGCAppDbContext _context;
        private Int64 vNo;
        //private Int64 TechnicalCounter;

        public TechnicalController()
        {
            _context = new SGCAppDbContext();
        }

        protected override void Dispose(bool disposing)
        { 
            _context.Dispose();
        }

        public ActionResult NewTechnical(IssuesVsViewModel issues)
        {
            //Technical technical = new Technical();
            
            var issue = _context.Issuess.SingleOrDefault();
            //var technical = GetTitleAndDescription(id);
            //Session["StatusId"] = id;
            if (issue.StatusId > 1) {
                return Content("This Technical Accepted");
            }
            else {
                
                vNo = StatusPass();
                _context.SaveChanges();
                return RedirectToAction("Technical" , vNo);
            }
        }

        public ActionResult Index()
        {
            var dEpart = _context.Issuess.Include(c => c.Status).OrderByDescending(c => c.IssuesId).ToList();
            return View(dEpart);
        }

        public ActionResult Technical(Int64 id)
        {   
            var tech = _context.Issuess.SingleOrDefault(c => c.IssuesId == id);
            return RedirectToAction("Technical", tech);
        }


        public ActionResult ViewTechnical(long id)
        {
            var issue = _context.Statuses.SingleOrDefault(c => c.StatusId == id);
            if (issue.StatusId > 1) {
                return Content("this technical has been viewed this issue already");
            }
            else { 
                string vNo = GetTitleAndDescription(id);
            }
            return View("TechnicalForm");
        }
         

        [HttpPost]
        [ValidateAntiForgeryToken]
        private Int64 StatusPass()
        {
            var rec = _context.Issuess.SingleOrDefault();
            vNo = rec.StatusId;
            //ViewBag.viewbag = "Your Ticket No. is: " + vNo;
            _context.SaveChanges();
            return vNo + 1;
        }

        private string GetTitleAndDescription(Int64 id)
        {
            var rec = (from issue in _context.Issuess select new { IssueId = issue.IssuesId, Title = issue.Title, Description = issue.Description}).SingleOrDefault(c => c.IssueId == id);
            string TitleIssue = rec.Title + " " + rec.Description;
            ViewBag.IssueTitle = "Your Description No. is: " + TitleIssue;
            return TitleIssue;
        }   

    }
}
