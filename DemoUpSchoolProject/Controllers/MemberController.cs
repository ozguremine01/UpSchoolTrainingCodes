using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entites;
namespace DemoUpSchoolProject.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member

        UpSchoolDBEntities db = new UpSchoolDBEntities();
        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMember.Where(x => x.MemberMail == mail).FirstOrDefault();
            ViewBag.name = values.MemberName;
            ViewBag.surname = values.MemberSurname;
            ViewBag.id = values.MemberID;

            return View();
        }
    }
}