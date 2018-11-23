using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ProjectCategoryController : Controller
    {
        private IRepository<ProjectCategory> projectCategoryRepository = new Repository<ProjectCategory>();
        public ActionResult Index()
        {
            return View(projectCategoryRepository.GetAll());
        }

        public ActionResult Insert(ProjectCategory projectCategory)
        {
            if(Request.Form.Count>0)
            {
                projectCategoryRepository.Create(projectCategory);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(projectCategoryRepository.GetId(id));
        }

        [HttpPost]
        public ActionResult Edit(ProjectCategory projectCategory)
        {
            ProjectCategory _projectCategory = projectCategoryRepository.GetId(projectCategory.ProjectCategoryID);
            _projectCategory.ProjectCategoryName = projectCategory.ProjectCategoryName;

            projectCategoryRepository.Edit(_projectCategory);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProjectCategory _projectCategory = projectCategoryRepository.GetId(id);
            projectCategoryRepository.Delete(_projectCategory);

            return RedirectToAction("Index");
        }
    }
}