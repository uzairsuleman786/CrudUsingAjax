using CrudUsingAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudUsingAjax.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDB edb = new EmployeeDB(); 
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var listOfEmployee = edb.ListAll();
            return Json(listOfEmployee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Employee emp)
        {
            var addEmployee = edb.Add(emp);
            return Json(addEmployee,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var getById = edb.ListAll().Find(x => x.EmployeeID.Equals(id));
            return Json(getById, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Employee emp)
        {
            var updateEmployee = edb.Update(emp);
            return Json(updateEmployee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var deleteEmployee = edb.Delete(id);
            return Json(deleteEmployee, JsonRequestBehavior.AllowGet);
        }
    }
}