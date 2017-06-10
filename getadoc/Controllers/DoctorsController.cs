using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using getadoc.Models;
using getadoc.Models.DbContexts;

namespace getadoc.Controllers
{   [Authorize(Roles ="Doctors")]
    public class DoctorsController : Controller
    {
        private DataDbContext db = new DataDbContext();

        // GET: Doctors
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }
#region outeractions
        // GET: Patients

        public ActionResult viewPatients()
        {
            return View(db.Patients.ToList());
        }
        
        // GET: Diseases
        public ActionResult viewDiseases()
        {
            return View(db.Diseases.ToList());
        }

       // GET: New Disease
        public ActionResult addDiseases()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addDiseases([Bind(Include = "id,name,symptom1,symptom2,symptom3,symptom4,cure,desc")]diseaseData data)
        {
            if (ModelState.IsValid)
            {
                db.Diseases.Add(data);
                db.SaveChanges();
                return RedirectToAction("viewDiseases"); 
            }
            return View(data);
        }
        // GET : Doctors/edit/2
        public ActionResult editDisease(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diseaseData disease = db.Diseases.Find(id);
            if (disease == null)
            {
                return HttpNotFound(); 
            }
            return View(disease);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editDisease([Bind(Include = "id,name,symptom1,symptom2,symptom3,symptom4,cure,desc")] diseaseData disease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("viewDiseases");
            }
            return View(disease);
        }
        // GET: Doctors/deleteDisease/5
        public ActionResult deleteDisease(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diseaseData doctors = db.Diseases.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/deleteDisease/5
        [HttpPost, ActionName("deleteDisease")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteDisease(int id)
        {
            diseaseData doctors = db.Diseases.Find(id);
            db.Diseases.Remove(doctors);
            db.SaveChanges();
            return RedirectToAction("viewDiseases");
        }
        // GET: Doctors/manageAppointments
        public ActionResult manageAppointments()
        {
            return View(db.Appointments.ToList());
        }
        public ActionResult approveAppointments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments _appt = db.Appointments.Find(id);
            if (_appt == null)
            {
                return HttpNotFound();
            }
            return View(_appt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult approveAppointments([Bind(Include = "id,appDate,reason,availble")]Appointments _appt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(_appt).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("manageAppointments");
            }
            return View(_appt);
        }
        public ActionResult rejectAppointment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments _apptDel = db.Appointments.Find(id);
            if (_apptDel == null)
            {
                return HttpNotFound();
            }
            return View(_apptDel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult rejectAppointment(int id)
        {
            Appointments _apptDel = db.Appointments.Find(id);
            db.Appointments.Remove(_apptDel);
            db.SaveChanges();
            return RedirectToAction("manageAppointments");
        }
        #endregion


        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,speciality,phoneno")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctors);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,speciality,phoneno")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctors);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctors doctors = db.Doctors.Find(id);
            db.Doctors.Remove(doctors);
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
    }
}
