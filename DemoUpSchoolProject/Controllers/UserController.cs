using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entites;
namespace DemoUpSchoolProject.Controllers
{
    public class UserController : Controller
    {
        UpSchoolDBEntities db = new UpSchoolDBEntities();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AboutPartial()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult ServicePartial()
        {
            var values = db.TblServices.ToList();
            return PartialView(values);
        }
    }
}