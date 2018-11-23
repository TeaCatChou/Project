using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project.Models;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            Members members = new Members();
            members.MemberID = Request.Form["MemberID"];
            members.Password = Request.Form["Password"];

            if (ProjectDataContext.memberLogin(members))
            {
                Session.RemoveAll();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, members.MemberID, DateTime.Now, DateTime.Now.AddMinutes(30), false, "text", FormsAuthentication.FormsCookiePath);
                return RedirectToAction("../Project/Index");
                //https://demo.tc/post/534
            }
            else
            {
                ViewBag.msg = "帳號密碼錯誤";
                return View("Index");
            }
        }        
       
    }
   
};