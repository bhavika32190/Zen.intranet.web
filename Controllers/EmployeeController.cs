using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zen.intranet.web.Models;

namespace Zen.intranet.web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        static List<Employee> empList = new List<Employee>()
            { 
                new Employee(){Firstname = "Bhavika", Id=1,FieldExperience=10 },
                new Employee(){Firstname = "Aayush", Id=2,FieldExperience=8 },
                new Employee(){Firstname = "Sakshi", Id=3,FieldExperience=6 },
                new Employee(){Firstname = "Keya", Id=4,FieldExperience=15 },
                new Employee(){Firstname = "Nehal", Id=5,FieldExperience=3 }

            };
  

        // GET: Employee
        //[NonAction]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            empList.OrderBy(e => e.Firstname);
            return View(empList);
            }


        [HttpGet]
        public ActionResult Create()
        {
          
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {

            empList.Add(emp);
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            //Get Record from db
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //Get Record from db
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            empList.Remove(model);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get Record from db
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            Employee dbEmployee = empList.Where(x => x.Id == emp.Id).FirstOrDefault();
            empList.Remove(dbEmployee);
            dbEmployee = emp;
            empList.Add(dbEmployee);
            empList.OrderBy(e => e.Firstname);
            return RedirectToAction("List");
        }


        //public ActionResult Create()
        //{
        //    return View();

        //}
        //[HttpGet]
        //public ActionResult Details()
        //{
        //    var model = empList.Where(x => x.Id == id).FirstorDefault();
        //    return View(model);
        //}


        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    var model = empList.Where(x => x.Id == id).FirstorDefault();
        //    empList.Remove(model);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
            public ActionResult html()
            {
                List<string> Topics = new List<string> { "pldc", "toc", "cao" };
                ViewBag.tp = Topics;
                ViewBag.Date = DateTime.Now.ToString();
                var model = new HtmlHelperModel() { Id = 1, Details = "is learning", IsActive = true };
                return View(model);

            }

            [HttpPost]
        public ActionResult html(HtmlHelperModel model)
        {
            //save data to db

            return RedirectToAction("Index");
        }

    }



    public class HtmlHelperModel
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
    }
}