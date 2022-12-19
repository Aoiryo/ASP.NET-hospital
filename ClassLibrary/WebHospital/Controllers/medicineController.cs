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
    public class medicineController : Controller
    {
        private Model1 db = new Model1();

        // GET: medicine
        public ActionResult Index()
        {
            return View(db.medicine.ToList());
        }

        // GET: medicine/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine medicine = db.medicine.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: medicine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: medicine/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicine1,price,medicineRemainingQuantity,location")] medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.medicine.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicine);
        }

        // GET: medicine/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine medicine = db.medicine.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: medicine/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicine1,price,medicineRemainingQuantity,location")] medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        // GET: medicine/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine medicine = db.medicine.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            medicine medicine = db.medicine.Find(id);
            db.medicine.Remove(medicine);
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

        public ActionResult checkStatus(long patientId)
        {
            if (((user)Session["Current"]).roleID != 3)
            { // not medicine management personnel
                return View("NoPermission");
            }

            // fetch data from all orders, which is from the specific patient, and is the paid prescription
            List<order> orderList = db.order.Where(p => p.patientId == patientId && p.orderStatus == "paid" && p.orderType == "prescription").ToList();

            if (orderList == null)
            {
                return View("NoAvailablePrescription");
            }
            else return View(orderList);
        }
        // add buttons in each row of the list to commit updates, the person should look at the order detail in order to type in correct medicine

        public ActionResult Update(order o, string medicine, int requestingQuantity)
        {
            medicine md = db.medicine.Find(medicine);
            if (requestingQuantity <= md.medicineRemainingQuantity)
            {
                md.medicineRemainingQuantity -= requestingQuantity;
            }
            o.orderStatus = "finished";
            db.SaveChanges();
            return View();
        }
    }
}