using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entites;
namespace DemoUpSchoolProject.Controllers
{
    public class StatisticController : Controller
    {
        UpSchoolDBEntities db = new UpSchoolDBEntities();

        // GET: Statistic
        public ActionResult Index()
        {
            //referansların toplam sayısı
            ViewBag.v1= ViewBag.countTestimonial = db.TblTestimonial.Count();
            //istanbuldaki referans sayısı
            ViewBag.v2 =ViewBag.countTestimonialByCityİstanbul = db.TblTestimonial.Where(x => x.City == "İstanbul").Count();
            ViewBag.v3 = ViewBag.countTestimonialByCityİstanbul = db.TblTestimonial.Where(x => x.Proffession != "Yazılım Mühendisi").Count();
            ViewBag.v4 = ViewBag.countTestimonialByCityİstanbul = db.TblTestimonial.Where(x => x.City == "Trabzon").Select(y =>y.NameSurname).FirstOrDefault();

            ViewBag.v5 = ViewBag.countTestimonialByCityİstanbul = db.TblTestimonial.Average(x => x.Balance);

            return View();
        }
    }
}