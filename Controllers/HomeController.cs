using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Archive_of_views.Models;

namespace Archive_of_views.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            try
            {
                var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
                if (check_id == null)
                    throw new Exception();
                return RedirectToAction("Personal_record","Home");
            }
            catch
            {

            }

            return View();
        }
        public ActionResult Personal_record()
        {
            var res = new Person();
            

            return View(res);
        }

        public ActionResult List(string what)
        {
            var res = new List_view_all();


            return View(res);
        }
        public ActionResult Film_view(string what)
        {
            var res = new Film();


            return View(res);
        }
        public ActionResult Series_view(string what)
        {
            var res = new Series();


            return View(res);
        }
        public ActionResult Book_view(string what)
        {
            var res = new Book();


            return View(res);
        }

        [ChildActionOnly]
        public ActionResult Main_header()
        {
            
                var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ViewBag.My_id = check_id;
            


            return PartialView();
        }

    }
}