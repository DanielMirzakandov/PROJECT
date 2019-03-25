using MVC5_proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_proj.ModelBinders;
using MVC5_proj.Dal;
using MVC5_proj.ModelView;
using System.Threading;

namespace MVC5_proj.Controllers
{
    public class UserController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        //SignIn
        [HttpPost]
        public ActionResult SignUp(Patient patient)
        {
            UserDal dal = new UserDal();
            List<Patient> q = (from p in dal.patients where p.ID.Equals(p.ID) select p).ToList<Patient>();

            if (q.Count() == 0)
            {
                dal.patients.Add(patient);//in Memorey adding
                dal.SaveChanges();
                TempData["yes"] = "Welcome to Health Care!";
                return RedirectToAction("ShowSignUp", "Home");
            }

            TempData["no"] = "You already Have An Acoount here";
            return RedirectToAction("ShowSignUp", "Home");
        }

        //Contact 
        [HttpPost]
        public ActionResult Send(Contact contact)
        {
            UserDal dal = new UserDal();

            //searching a person from DB with query and saves in DB if found other wise returining with a msg
            List<User> q = (from u in dal.Users where u.ID.Equals(contact.ID) select u).ToList<User>();

            if (q.Count() > 0)
           {
                dal.Contacts.Add(contact);//in Memorey adding
                dal.SaveChanges();//adding to DB from Memorey
                TempData["yes"] = "Thank you for contacting us – we will get back to you soon!";
                return RedirectToAction("ShowContact", "Home");
           }

            TempData["no"] = "You Dont Have An Acoount here Please Register First";

            return RedirectToAction("ShowContact", "Home");
        }


    }
}