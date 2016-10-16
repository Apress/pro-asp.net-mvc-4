using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMVCPattern.Models;

namespace TheMVCPattern.Controllers {

    public class AdminController : Controller {
        IMembersRepository membersRepository;

        public AdminController(IMembersRepository repositoryParam) {
            membersRepository = repositoryParam;
        }

        public ActionResult ChangeLoginName(string oldLoginParam, string newLoginParam) {
            Member member = membersRepository.FetchByLoginName(oldLoginParam);
            member.LoginName = newLoginParam;
            membersRepository.SubmitChanges();
            // ... now render some view
            return View();
        }
    }
}
