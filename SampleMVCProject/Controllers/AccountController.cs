using SampleMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace SampleMVCProject.Controllers
{
    public class AccountController : Controller
    {
        AllContext db = new AllContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]

        public ActionResult Login(string UserName, string Password, string ReturnUrl)
        {
            if (FormsAuthentication.Authenticate(UserName, Password))
            {
                FormsAuthentication.SetAuthCookie(UserName, true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View();

        }



        //public ActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SignUp(System.Web.Security.Membership membership)
        //{
        //    using (var ctxt= new AllContext())
        //    {
        //        ctxt.Memberships.Add(membership);
        //        ctxt.SaveChanges();
        //    }
        //    return RedirectToAction("Login");
        //}
    }
}