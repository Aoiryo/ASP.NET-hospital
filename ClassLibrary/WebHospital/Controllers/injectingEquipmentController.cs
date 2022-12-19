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
    public class injectingEquipmentController : Controller
    {
        private Model1 db = new Model1();

        // GET: injectingEquipment
        public ActionResult Index()
        {
            return View(db.injectingEquipment.ToList());
        }

        // GET: injectingEquipment/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            injectingEquipment injectingEquipment = db.injectingEquipment.Find(id);
            if (injectingEquipment == null)
            {
                return HttpNotFound();
            }
            return View(injectingEquipment);
        }

        // GET: injectingEquipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: injectingEquipment/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "injectingEquipment1,price,injectingEquipmentRemainingQuantity,location")] injectingEquipment injectingEquipment)
        {
            if (ModelState.IsValid)
            {
                db.injectingEquipment.Add(injectingEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(injectingEquipment);
        }

        // GET: injectingEquipment/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            injectingEquipment injectingEquipment = db.injectingEquipment.Find(id);
            if (injectingEquipment == null)
            {
                return HttpNotFound();
            }
            return View(injectingEquipment);
        }

        // POST: injectingEquipment/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "injectingEquipment1,price,injectingEquipmentRemainingQuantity,location")] injectingEquipment injectingEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(injectingEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(injectingEquipment);
        }

        // GET: injectingEquipment/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            injectingEquipment injectingEquipment = db.injectingEquipment.Find(id);
            if (injectingEquipment == null)
            {
                return HttpNotFound();
            }
            return View(injectingEquipment);
        }

        // POST: injectingEquipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            injectingEquipment injectingEquipment = db.injectingEquipment.Find(id);
            db.injectingEquipment.Remove(injectingEquipment);
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

        public ActionResult Update(string injectingEquipment, int injectingEquipmentRemainingQuantity)
        {
            injectingEquipment ie = db.injectingEquipment.Find(injectingEquipment);
            if (injectingEquipmentRemainingQuantity > 0)
            {
                ie.injectingEquipmentRemainingQuantity = injectingEquipmentRemainingQuantity - 1;
            }
            db.SaveChanges();
            return View();
        }
    }
}
