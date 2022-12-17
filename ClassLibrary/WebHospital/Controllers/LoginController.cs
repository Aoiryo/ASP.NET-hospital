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
    public class LoginController : Controller
    {
        private Model1 db = new Model1();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.patient.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "patientID,IDNumber,name,gender,age,contactInformation,birthday")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.patient.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Login/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "patientID,IDNumber,name,gender,age,contactInformation,birthday")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            patient patient = db.patient.Find(id);
            db.patient.Remove(patient);
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

        public ActionResult userLogin(string loginName, string password)
        {
            user User = db.user.Find(loginName);
            if (User == null || User.password != password) return View("InvalidUserOrPassword");
            long RoleId = User.roleID;
            switch (RoleId) { 
                case (0): // patient
                    {
                        List<patient> list = db.patient.Where(b => b.IDNumber.Equals(loginName)).ToList();
                        Session["Current"] = User; // Save current user info to Session
                        return View(Session["Current"]);
                    }
                // To add...
            };
                
            return View(); // Log in to homepage of the patient
        }

        /* This is aborted
         public ActionResult adminLogin(string loginName, string password)
        {
            return View();
        }
        */

        public ActionResult resetPassword(string loginName, string password, string confirmPassword)
        {
         
            if (((user)Session["Current"]).IDNumber != loginName)
            {
                return View("NoPermission");
            }
            else
            {
                if (password != confirmPassword) return View("NotSame");
                else
                {
                    user std = db.user.Find(loginName);
                    std.password = confirmPassword;
                    db.SaveChanges();
                    return View();
                }
            }
        }
    }
}
