using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entites;
namespace DemoUpSchoolProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        UpSchoolDBEntities db = new UpSchoolDBEntities();
        public ActionResult Inbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMessage.Where(x=>x.ReceiverMail == mail).ToList();
            return View(values);
        }
        public ActionResult Outbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMessage.Where(x => x.SenderMail == mail).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage p)
        {
            var mail = Session["MemberMail"].ToString();
            p.MessageDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            p.SenderMail = mail;
            p.SenderNameSurname = db.TblMember.Where(x => x.MemberMail == mail).Select(y=>y.MemberName + " "+ y.MemberSurname).FirstOrDefault();
            //Önemli aşağıdaki satır
            p.RecevierNameSurnem = db.TblMember.Where(x => x.MemberMail == p.ReceiverMail).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            db.TblMessage.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult MessageDetails()
        {
            return View();
        }
    }
}