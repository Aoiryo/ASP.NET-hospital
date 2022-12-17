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
    public class caseController : Controller
    {
        private Model1 db = new Model1();

        // GET: case
        public ActionResult Index()
        {
            return View(db.medicalHistory.ToList());
        }

        // GET: case/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicalHistory medicalHistory = db.medicalHistory.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // GET: case/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: case/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "patientID,diagnosisTime,department,medicalPersonnelID,diagnosisResult")] medicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.medicalHistory.Add(medicalHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalHistory);
        }

        // GET: case/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicalHistory medicalHistory = db.medicalHistory.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // POST: case/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "patientID,diagnosisTime,department,medicalPersonnelID,diagnosisResult")] medicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalHistory);
        }

        // GET: case/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicalHistory medicalHistory = db.medicalHistory.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // POST: case/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            medicalHistory medicalHistory = db.medicalHistory.Find(id);
            db.medicalHistory.Remove(medicalHistory);
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

        public ActionResult addNew(long patientId, DateTime diagnosisTime, string department, 
                                    long medicalPersonnelId, string diagnosisResult)
            // There should be a method searching for the patient ID for a certain patient with his/her ID number,
            // or, it will be impractical for the doctor to know that ahead. 
        {
            medicalHistory his = new medicalHistory()
            {
                patientID = patientId,
                diagnosisTime = diagnosisTime,
                department = department,
                medicalPersonnelID = medicalPersonnelId,
                diagnosisResult = diagnosisResult
            };
            if (ModelState.IsValid)
            {
                db.medicalHistory.Add(his);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult showCase(long patientId) // the same problem as above
        {
            List<medicalHistory> his = db.medicalHistory.Where(history => history.patientID == patientId).ToList();
            return View(his);
        }

        public ActionResult editCase(long patientId, DateTime dateTime, string diagnosisResult) // the same problem as above
        {
            medicalHistory his = db.medicalHistory.Find(patientId, dateTime);
            his.diagnosisResult = diagnosisResult;
            db.SaveChanges();
            return View();
        }
    }
}
