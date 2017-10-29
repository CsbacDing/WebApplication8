using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }  //seems like have no use of this page when HomeController combines in this project.

        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                OurDbContext db = new OurDbContext();
                db.UserAccounts.Add(account);
                db.SaveChanges();
                ViewBag.Message = account.Username + " Successfully Registered.";
                /*using (OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Username + " Successfully Registered";  */
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.UserAccounts.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.Username.ToString();
                    Session["Username"] = usr.Username.ToString();  //have no use in authorization
                    
                    return RedirectToAction("LoggedIn");

                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }

        
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        
        public ActionResult Logout()
        {

                  Session.Clear();
               // Session["UserID"] = null; 
               //this is not good cause session is still existing.
                return RedirectToAction("Index","Home");
            
        }
    }
}