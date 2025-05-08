using IFTR.DAL;
using IFTR.DAL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IFTR.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if (password != null && email != null)
                {
                    string Password = Utility.HashPass(password, email);
                    var obj = UserDataAccess.GetUserDetails(email, Password);
                    if (obj != null && obj.UserName != null)
                    {
                        if (obj.IsActive)
                        {
                            Session["EmailAddress"] = obj.EmailAddress;
                            Session["UserName"] = obj.UserName;
                            Session["UserType"] = obj.UserType;
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else
                        {
                            ViewBag.Err = "User is not active. Please Contact Administrator";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Err = "Invalid credentials. Please try again";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Err = "Invalid Email or Password. Please try again";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Users()
        {
            try
            {
                var dtUsers = UserDataAccess.GetAllUsers();
                var dtUserTypes = UserDataAccess.GetAllUserTypes();
                ViewData["Users"] = dtUsers;
                ViewData["UserTypes"] = dtUserTypes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult SubCategories()
        {
            return View();
        }
        public ActionResult PageContent()
        {
            return View();
        }
    }
}