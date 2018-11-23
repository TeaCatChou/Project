using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class MembersController : Controller
    {
        private IRepository<Members> memberRepository = new Repository<Members>();
        public ActionResult Index()
        {
            return View(memberRepository.GetAll());
        }

        public ActionResult Insert(Members _members)
        {
            if(Request.Form.Count>0)
            {
                _members.MemberGUID = Guid.NewGuid();
                _members.CreateDate = DateTime.Now;
                memberRepository.Create(_members);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(memberRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Members members)
        {
            Members _members = memberRepository.GetById(members.MemberGUID);
            _members.Password = members.Password;
            _members.ModifiedDate = DateTime.Now;
            memberRepository.Edit(_members);

            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid? id)
        {
            Members _members = memberRepository.GetById(id);
     

            memberRepository.Delete(_members);

            return RedirectToAction("Index");
        }



    }
}