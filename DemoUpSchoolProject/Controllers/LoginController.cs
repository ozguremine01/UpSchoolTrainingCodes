using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoUpSchoolProject.Models.Entites;
namespace DemoUpSchoolProject.Controllers
{
    public class LoginController : Controller
    {
        UpSchoolDBEntities db = new UpSchoolDBEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMember p)
        {
            var values = db.TblMember.FirstOrDefault(x => x.MemberMail == p.MemberMail && x.MemberPassword == p.MemberPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.MemberMail, false);
                Session["MemberMail"] = p.MemberMail;
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index");
            }
               
        }
    }
}