using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class TaskStatusController : Controller
    {
        private IRepository<TaskStatus> taskStatusRepository = new Repository<TaskStatus>();

        public ActionResult Index()
        {
            return View(taskStatusRepository.GetAll());
        }

        public ActionResult Insert(TaskStatus taskStatus)
        {
            if(Request.Form.Count>0)
            {
                taskStatusRepository.Create(taskStatus);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(taskStatusRepository.GetId(id));
        }

        [HttpPost]
        public ActionResult Edit(TaskStatus taskStatus)
        {
            TaskStatus _taskStatus = taskStatusRepository.GetId(taskStatus.TaskStatusID);
            _taskStatus.TaskStatusName = taskStatus.TaskStatusName;

            taskStatusRepository.Edit(_taskStatus);

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            TaskStatus _taskStatus = taskStatusRepository.GetId(id);
            taskStatusRepository.Delete(_taskStatus);

            return RedirectToAction("Index");
        }

    }
}