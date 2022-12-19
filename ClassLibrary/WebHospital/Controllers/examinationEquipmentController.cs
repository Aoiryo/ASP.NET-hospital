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
    public class examinationEquipmentController : Controller
    {
        private Model1 db = new Model1();

        // GET: examinationEquipment
        public ActionResult Index()
        {
            return View(db.examinationEquipment.ToList());
        }

        // GET: examinationEquipment/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examinationEquipment examinationEquipment = db.examinationEquipment.Find(id);
            if (examinationEquipment == null)
            {
                return HttpNotFound();
            }
            return View(examinationEquipment);
        }

        // GET: examinationEquipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: examinationEquipment/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "examinationEquipment1,examinationEquipmentStatus")] examinationEquipment examinationEquipment)
        {
            if (ModelState.IsValid)
            {
                db.examinationEquipment.Add(examinationEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examinationEquipment);
        }

        // GET: examinationEquipment/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examinationEquipment examinationEquipment = db.examinationEquipment.Find(id);
            if (examinationEquipment == null)
            {
                return HttpNotFound();
            }
            return View(examinationEquipment);
        }

        // POST: examinationEquipment/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "examinationEquipment1,examinationEquipmentStatus")] examinationEquipment examinationEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examinationEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examinationEquipment);
        }

        // GET: examinationEquipment/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examinationEquipment examinationEquipment = db.examinationEquipment.Find(id);
            if (examinationEquipment == null)
            {
                return HttpNotFound();
            }
            return View(examinationEquipment);
        }

        // POST: examinationEquipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            examinationEquipment examinationEquipment = db.examinationEquipment.Find(id);
            db.examinationEquipment.Remove(examinationEquipment);
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

        public ActionResult Update(string examinationEquipment, string examinationEquipmentStatus)
        {
            examinationEquipment ee = db.examinationEquipment.Find(examinationEquipment);
            ee.examinationEquipmentStatus = examinationEquipmentStatus;
            db.SaveChanges();
            return View();
        }
    }
}
