using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entites;
namespace DemoUpSchoolProject.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        /*
         * ToList
         * Add
         * Remove
         * Where
         * */

        UpSchoolDBEntities db = new UpSchoolDBEntities();
        public ActionResult Index()
        {
            var values= db.TblServices.ToList();
            return View(values);
            
        }

        [HttpGet]
        public ActionResult AddService()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblServices p)
        {
            db.TblServices.Add(p);

            var pState = db.Entry(p).State;
            db.Entry(p).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // services/deleteservice/id
        public ActionResult DeleteService(int id)
        {
            var values = db.TblServices.Find(id);
            db.TblServices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // [HttpGet]
        /*
        public ActionResult UpdateService()
        {
            return View();
        }
        */
        // services/updateservice/id
        // [HttpPost]
        /*
        public ActionResult UpdateService(TblServices p, int id, string title)
        {
            var values = db.TblServices.FirstOrDefault(x => x.ServiceID == id);

            values.Title = p.Title;
            db.Entry(values).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        */
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblServices.Find(id);
            return View(values);
    }
        [HttpPost]
        public ActionResult UpdateService(TblServices p)
        {
            var values = db.TblServices.Find(p.ServiceID);
            values.Title = p.Title;
            var entityState = db.Entry(values).State;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetAllServices()
        {
            var services = db.TblServices.AsNoTracking().ToList();
            var state = db.Entry(services.First()).State;
            return View(services);
        }
    }
}