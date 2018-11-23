using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class JobTitleController : Controller
    {
        private IRepository<JobTitle> jobTRepository = new Repository<JobTitle>();
        public ActionResult Index()
        {
            return View(jobTRepository.GetAll());
        }

        public ActionResult Insert(JobTitle jobTitle)
        {
            if (Request.Form.Count>0)
            {
                jobTitle.TitleGUID = Guid.NewGuid();
                jobTRepository.Create(jobTitle);

                return RedirectToAction("Index");
            }

                return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            return View(jobTRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(JobTitle jobTitle)
        {
            JobTitle _jobTitle = jobTRepository.GetById(jobTitle.TitleGUID);
            _jobTitle.TitleID = jobTitle.TitleID;
            _jobTitle.TitleName = jobTitle.TitleName;

            jobTRepository.Edit(_jobTitle);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid? id)
        {
            JobTitle _jobTitle = jobTRepository.GetById(id);
            jobTRepository.Delete(_jobTitle);

            return RedirectToAction("Index");
        }
    }
}