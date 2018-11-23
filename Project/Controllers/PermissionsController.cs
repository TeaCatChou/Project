using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class PermissionsController : Controller
    {
        private IRepository<Permissions> permissionsRepository = new Repository<Permissions>();
        public ActionResult Index()
        {
            return View(permissionsRepository.GetAll());
        }

        public ActionResult Insert(Permissions _permissions)
        {
            if (Request.Form.Count > 0) 
            {
                _permissions.PermissionsGUID = Guid.NewGuid();
                permissionsRepository.Create(_permissions);

                return RedirectToAction("Index");
            }
            return View();
        }




    }
}