using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class DepartmentController : Controller
    {
        private IRepository<Department> depRepository = new Repository<Department>();
        Department db = new Department();
        public ActionResult Index()
        {
            return View(depRepository.GetAll());
        }

        public ActionResult Insert()
        {
            if (Request.Form.Count > 0)
            {
                Department _department = new Department();
                if (!(Request.Form["ParentDepartmentGUID"] == null || Request.Form["ParentDepartmentGUID"] == "0"))
                {
                    _department.ParentDepartmentGUID = new Guid(Request.Form["ParentDepartmentGUID"]);
                }
                _department.DepartmentGUID = Guid.NewGuid();
                _department.DepartmentName = Request.Form["DepartmentName"];
                depRepository.Create(_department);
                return RedirectToAction("Index");
            }
            return View(depRepository.GetAll());
        }

        public ActionResult Delete(Guid? id)
        {
            Department department = depRepository.GetById(id);
            depRepository.Delete(department);

            return RedirectToAction("Index");
        }
    }
}