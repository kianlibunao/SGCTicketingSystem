using System;
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
    public class TechnicalTransactionController : Controller
    {
        // GET: TechnicalTransaction
        SGCAppDbContext _context;
        public ActionResult Index()
        {
            var dEpart = _context.Technicals.Include(c => c.TechnicalSum).OrderByDescending(c => c.TechnicalId).ToList();
            return View(dEpart);
        }

        public TechnicalTransactionController()
        {
            _context = new SGCAppDbContext();
        }
            
        public ActionResult ViewTransaction(Int64 id)
        {
            //ViewBag.IssueTitle = GetTitleAndDescription(id);
            var rec = _context.TechnicalTransactions.Where(c => c.TechnicalTransactionId == id).FirstOrDefault();
            return View();
             //return View("TechnicalForm");
        }


        public ActionResult GenerateTransaction()
        {
            return View();
        }

        public ActionResult GenerateTransaction(TechnicalTransaction model)
        {
            _context.TechnicalTransactions.Add(model);
            _context.SaveChanges();
            return View();
        }

        //public ActionResult History()
        //{
        //    return View();
        //}

        //private Int64 TicketDescription()
        //{
        //    var rec = _context.Technicals.SingleOrDefault();
        //    Int64 vTickNum = rec.TechnicalId;
        //    ViewBag.viewbag = "The Ticket No. is: " + vTickNum;
        //    _context.SaveChanges();
        //    return vTickNum;
        //}
          

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //private string GetTitleAndDescription(Int64 id)
        //{
        //    var rec = (from issue in _context.Issuess select new { IssueId = issue.IssuesId, Title = issue.Title, Description = issue.Description }).SingleOrDefault(c => c.IssueId == id);
        //    string TitleIssue = rec.Title + " " + rec.Description;
        //    return TitleIssue;
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        

    }
}
