using MVC5_proj.Dal;
using MVC5_proj.Models;
using MVC5_proj.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_proj.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowHomePage()
        {
            return View();
        }

        public ActionResult ShowContact()
        {
            return View();
        }

        public ActionResult ShowAbout()
        {

            return View();
        }

        public ActionResult ShowSignUp()
        {
            return View();
        }
    }
}