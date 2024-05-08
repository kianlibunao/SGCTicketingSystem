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
    public class UserController : Controller
    {
        // GET: User
        private SGCAppDbContext _context;
        public UserController()
        {
            _context = new SGCAppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewUser()
        {
            User user = new User();
            var viewModel = new UserVsUserTypeViewModel
            {
                User = user,
                UserTypes = _context.UserTypes.ToList()
            };
            return View("UserForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.UserId == id);
            if (user == null)
                return HttpNotFound();
            var viewModel = new UserVsUserTypeViewModel
            {
                User = user,
                UserTypes = _context.UserTypes.ToList()
            };
            return View("UserForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new UserVsUserTypeViewModel
                {
                    User = user,
                    UserTypes = _context.UserTypes.ToList()
                };

                return View("UserForm", viewModel);
            }

            if (user.UserId == 0)
            {
                Int64 vid = user.UserTypeId; 
                user.Status = true;
                _context.Users.Add(user);
            }
            else
            {
                var UserInDb = _context.Users.Single(c => c.UserId == user.UserId);
                UserInDb.FullName = user.FullName;
                UserInDb.Username = user.Username;
                UserInDb.UserTypeId = user.UserTypeId;
                UserInDb.Password = user.Password;
                UserInDb.ConfirmedPassword = user.ConfirmedPassword;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }
        public ActionResult Index()
        {
            var user = _context.Users.Include(c => c.UserType).ToList();
            return View(user);
        }

        public ActionResult status(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            user.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "User");

        }
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserVsUserTypeViewModel
                {
                    User = user,
                    UserTypes = _context.UserTypes.ToList()
                };
                 if (user.UserTypeId == 1)
                {
                   Session["UserTypeId"] = user.UserTypeId;
                    user.UserTypeId = 1;
                    return RedirectToAction("index", "Home");
                }
                if (user.UserTypeId == 2)
                {
                    Session["UserTypeId"] = user.UserId;
                    user.UserTypeId = 2;
                    return RedirectToAction("index", "Home");
                }
                if (user.UserTypeId == 3)
                {
                    Session["UserTypeId"] = user.UserId;
                    user.UserTypeId = 3;
                    return RedirectToAction("index", "Home");
                }
                if (user.UserTypeId == 4)
                {
                    user.UserTypeId = 4;
                    Session["UserTypeId"] = user.UserId;
                    return RedirectToAction("index", "Home");
                }
                //if (user.UserTypeId == 1)
                //{
                //    ViewBag.view = "Administrator";
                //    return RedirectToAction("index","Home");
                //}
                //if (user.UserTypeId == 2)
                //{
                //    ViewBag.view = "SuperVisor";
                //    return RedirectToAction("index", "Home");
                //}
                //if (user.UserTypeId == 3)
                //{
                //    ViewBag.view = "PowerUser";
                //    return RedirectToAction("index", "Home");
                //}
                //if (user.UserTypeId == 4)
                //{
                //    ViewBag.view = "User";
                //    return RedirectToAction("index","Home");
                //}
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.FullName;
                Session["UserTypeId"] = user.UserTypeId;
                Session["UserType"] = user.UserType;
                return View("Index", viewModel);
            }
                String vpassword = user.Password;
                var loginuser = _context.Users.SingleOrDefault(c => c.Username == user.Username && c.Password == vpassword);
                if (loginuser == null)
                {
                return HttpNotFound();
                }
            return RedirectToAction("Index", "Home");
            }

        }
    }


    


