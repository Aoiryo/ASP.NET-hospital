using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

namespace WebHospital.Controllers
{
    public class registerController : Controller
    {
        private Model1 db = new Model1();


        // GET: registrationSessions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrationSession registrationSession = db.registrationSession.Find(id);
            if (registrationSession == null)
            {
                return HttpNotFound();
            }
            return View(registrationSession);
        }

        // GET: registrationSessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: registrationSessions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "registrationSessionID,registrationPersonnelID,patientID,registrationType,registrationObject,sessionTime,isStart,department")] registrationSession registrationSession)
        {
            if (ModelState.IsValid)
            {
                db.registrationSession.Add(registrationSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrationSession);
        }

        // GET: registrationSessions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrationSession registrationSession = db.registrationSession.Find(id);
            if (registrationSession == null)
            {
                return HttpNotFound();
            }
            return View(registrationSession);
        }

        // POST: registrationSessions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "registrationSessionID,registrationPersonnelID,patientID,registrationType,registrationObject,sessionTime,isStart,department")] registrationSession registrationSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrationSession);
        }

        // GET: registrationSessions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registrationSession registrationSession = db.registrationSession.Find(id);
            if (registrationSession == null)
            {
                return HttpNotFound();
            }
            return View(registrationSession);
        }

        // POST: registrationSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            registrationSession registrationSession = db.registrationSession.Find(id);
            db.registrationSession.Remove(registrationSession);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: registrationSessions
        public ActionResult Index()
        {
            string idNumber = ((user)Session["Current"]).IDNumber;
            List<patient> pa = db.patient.Where(p => p.IDNumber == idNumber).ToList(); // to get the patientID of the current user
            long patientId = pa[0].patientID;
            List<registrationSession> his = db.registrationSession.Where(p => p.patientID == patientId).ToList(); // get all registrations from the user
            Session["RegistrationList"] = his;
            return View(his);
        }

        public ActionResult showOrder() // write a button that can activate this method
        {
            List<order> orders = new List<order>();
            if (Session["RegistrationList"] != null)
            {
                foreach (var regis in (List<registrationSession>)Session["RegistrationList"]) // get orders from registrations
                {
                    List<order> temp= db.order.Where(p => p.registrationSessionID == regis.registrationSessionID).ToList();
                    order Order = temp[0];
                    orders.Add(Order);
                }
                return View(orders);
            }
            else return View();
        }

        public ActionResult search()
        {
            return View(db.scheduling.ToList());
        }

        public ActionResult search(string department, DateTime time, string timeDetail) // return available appointment positions
        {
            List<medicalPersonnel> people = db.medicalPersonnel.Where(p => p.department == department).ToList();
            List<scheduling> availablePeople = db.scheduling.Where(p => p.dutyTime == time && p.timeDetail == timeDetail).ToList();

            return View(availablePeople); // return a list of available # aligned with different departments
        }

        // leave a button on the right to display avialable positions for the doctor
        public int displayAvailableNumber(scheduling toSearch)
        {
            long personnelID = toSearch.medicalPersonnelID;
            int appointing = db.registrationSession.Where(p => p.time == toSearch.dutyTime && p.timeDetail == toSearch.timeDetail && p.medicalPersonnelId == personnelID).ToList().Count;
            int availableNumber = 30 - appointing;
            return availableNumber;
        }

        public ActionResult register(long? helperID, long patientID, long medicalPersonnelId, DateTime time, string department, string timeDetail)
        {
            if (Session["Current"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // not permitted to register without logging in
            }
            registrationSession s = new registrationSession()
            {
                isStart = true,
                registrationSessionID = (long)HttpContext.Application["registration"],
                patientID = patientID,
                medicalPersonnelId = medicalPersonnelId,
                time = time,
                timeDetail = timeDetail,
                sessionTime = DateTime.Now,
                department = department
            };

            HttpContext.Application["registration"] = (long)HttpContext.Application["registration"] + 1; // in case that the patient gets a second registration

            if (helperID != null) s.registrationPersonnelID = (long)helperID;
            db.registrationSession.Add(s);
            db.SaveChanges();

            order o = new order()
            {
                orderNumber = (long)HttpContext.Application["order"],
                registrationSessionID = s.registrationSessionID, 
                medicalPersonnelID = s.medicalPersonnelId,
                orderTime = DateTime.Now,
                orderType = "registration",
                orderStatus = "not paid", 
                payment = 5
            };

            HttpContext.Application["order"] = (long)HttpContext.Application["order"] + 1;
            db.order.Add(o);
            db.SaveChanges();
            // return View();
            return RedirectToAction("pay", o);
        }

        public ActionResult pay(order o) // difficult to implement without using API - not implemented yet
        {
            o.orderStatus = "paid";
            return View(o);
        }

        public ActionResult edit()
        {
            return View();
        }

        public ActionResult delete()
        {
            return View();
        }



    }
}
