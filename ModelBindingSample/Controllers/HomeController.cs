using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBindingSample.Models;

namespace ModelBindingSample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NoBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NoBindingPost()
        {
            string id = Request["Id"];
            string firstName = Request["FirstName"];
            string lastName = Request["LastName"];

            SetFlash(FlashMessageType.Success, "User saved!", firstName + " " + lastName + ", ID: " + id + " saved!");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult QueryStringBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QueryStringBinding(string ID, string firstName, string lastName)
        {
            SetFlash(FlashMessageType.Success, "User saved!", firstName + " " + lastName + ", ID: " + ID + " saved!");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ClassBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClassBinding(Employee employee)
        {
            SetFlash(FlashMessageType.Success, "User saved!", employee.FirstName + " " + employee.LastName + ", ID: " + employee.ID + " at building " + employee.WorkLocation.BuildingName + " saved!");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ListBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListBinding(List<Employee> employees)
        {
            string namesList = "";
            foreach(var emp in employees)
            {
                namesList += emp.FirstName + " ";
            }
            SetFlash(FlashMessageType.Success, "Employees saved!", "First names: " + namesList);
            return RedirectToAction("Index");
        }


        private void SetFlash(FlashMessageType type, string title, string text)
        {
            TempData["FlashMessage.Type"] = type;
            TempData["FlashMessage.Text"] = text;
            TempData["FlashMessage.Title"] = title;
        }
    }
}