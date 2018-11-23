using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class TaskDetailStatusController : Controller
    {
        private IRepository<TaskDetailStatus> TDstatusRepository  = new Repository<TaskDetailStatus>();

        public ActionResult Index()
        {
            return View(TDstatusRepository.GetAll());
        }

        public ActionResult Insert(TaskDetailStatus taskDetailStatus)
        {
            if(Request.Form.Count>0)
            {
                TDstatusRepository.Create(taskDetailStatus);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(TDstatusRepository.GetId(id));
        }

        [HttpPost]
        public ActionResult Edit(TaskDetailStatus taskDetailStatus)
        {
            TaskDetailStatus _taskDetailStatus = TDstatusRepository.GetId(taskDetailStatus.TaskDetailStatusID);
            _taskDetailStatus.TaskDetailStatusName = Request.Form["TaskDetailStatusName"];

            TDstatusRepository.Edit(_taskDetailStatus);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TaskDetailStatus _taskDetailStatus = TDstatusRepository.GetId(id);
            TDstatusRepository.Delete(_taskDetailStatus);

            return RedirectToAction("Index");
        }
    }
}