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


        [HttpPost]
        public ActionResult SignIn(Patient patient)
        {
            //sabing data from DB and searching if there is a match for admin or user
            UserDal dal = new UserDal();
            List<Patient> q = (from u in dal.patients where u.ID.Equals(patient.ID) select u).ToList<Patient>();
            //List<Manager> AdminQ = (from m in dal.Managers where m.ID.Equals(user.ID) select m).ToList<Manager>();

            /*if (AdminQ.Count() > 0 && AdminQ[0].ID.Equals(user.ID) && AdminQ[0].Password.Equals(user.Password))
            {
                Session["Admin"] = "Hello Admin";
                return RedirectToAction("ShowHomePage", "Home");
            }
            */
            if (q.Count() > 0 && q[0].ID.Equals(patient.ID) && q[0].password.Equals(patient.password))
            {
                Session["Patient"] = "Hello " + q[0].fname + " " + q[0].lname;
                return RedirectToAction("ShowHomePage", "Home");
            }

            TempData["noSignIn"] = "You Dont Have An Acoount here Please Register First";

            return RedirectToAction("ShowSignIn", "Home");
        }

        //SignUp
        [HttpPost]
        public ActionResult SignUp(Patient patient)
        {
            UserDal dal = new UserDal();
            List<Patient> q_id = (from p in dal.patients where p.ID.Equals(patient.ID) select p).ToList<Patient>();
            List<Patient> q_username = (from p in dal.patients where p.username.Equals(patient.username) select p).ToList<Patient>();

            //first visit in site user doesnt exsit 
            if (q_id.Count() == 0)
            {
                dal.patients.Add(patient);
                dal.SaveChanges();
                if (q_username.Count() > 0)
                {
                    TempData["taken"] = patient.username + " Sorry... username already taken";
                    return RedirectToAction("ShowSignUp", "Home");
                }
                TempData["yes"] = patient.ID+"Welcome to HealthCare now you are in our hands!";
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
            //List<Patient> q = (from u in dal.patients where u.ID.Equals(contact.ID) select u).ToList<Patient>();
            //List<Contact> p = dal.Contacts.ToList<Contact>();
            //UserViewModel uvm = new UserViewModel();
            //uvm.contacts = p;
            
            //return View("ShowContact", uvm);
            if (true)
           {
                dal.contacts.Add(contact);//in Memorey adding
                dal.SaveChanges();//adding to DB from Memorey
                TempData["yes"] = contact.ID+"Thank you for contacting us – we will get back to you soon!";
                return RedirectToAction("ShowContact", "Home");
           }

            TempData["no"] = "You Dont Have An Acoount here Please Register First";

            return RedirectToAction("ShowContact", "Home");
        }


    }
}