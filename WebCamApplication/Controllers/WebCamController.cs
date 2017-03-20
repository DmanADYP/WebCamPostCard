using log4net;
using System;
using System.Web.Mvc;
using WebCamApplication.Common;
using WebCamApplication.Models;
using WebCamApplication.ViewModels;

namespace WebCamApplication.Controllers
{

    public class WebCamController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(EmailImage));
        // GET: WebCam
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
               return RedirectToAction("Index", "Login");
               
            }
            
            return View();
        }
       
        [HttpPost]
        public ActionResult Index(DrawingModel model)
        {
            try
            {

           
            _ViewModelCam vmc = new _ViewModelCam();
            
             model.UserName = Session["user"].ToString();
              vmc._vdm = model;
                if (model.Email =="Email")
            {
                EmailCredModel ecm = new EmailCredModel();
                EmailImage EI = new EmailImage(ecm);
                EI.EmailMethod(vmc._vdm);
            }


            if (model.Save == "Save Image To Browser")
            {           
                Save s = new Save();
                s.SaveToThePage(vmc._vdm, System.Web.HttpContext.Current);
            }



            return View(vmc);
            }
            catch (Exception e)
            {

                log.Error(e);
                return RedirectToAction("Index", "Login");
            }
            finally
            {
               
            }


        }

        

       }
}