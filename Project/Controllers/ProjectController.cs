using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ProjectController : Controller
    {
        
        private IRepository<Project.Models.Project> projectRepository = new Repository<Project.Models.Project>();
        public ActionResult Index()
        {
            return View(projectRepository.GetAll());
        }
    }
}