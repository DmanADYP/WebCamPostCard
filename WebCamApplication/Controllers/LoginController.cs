using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCamApplication.Models;

namespace WebCamApplication.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        // GET: Login
        public ActionResult Index(LoginModel lm)
        {
            if (lm.Name !="" && lm.Password !="")
            {
                Session["user"] = lm.Name;
                return RedirectToAction("Index", "WebCam");
            }
          
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}