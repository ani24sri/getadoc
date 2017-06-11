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
{   
    [Authorize(Roles ="Patients")]
    public class PatientsController : Controller
    {
        private DataDbContext db = new DataDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        #region outeractions
        [HttpGet]
        public ActionResult feedback()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult feedback([Bind(Include = "id,rate,feed")]feedback appointments)
        {
            if (ModelState.IsValid)
            {
                db.feebak.Add(appointments);
                db.SaveChanges();
                return RedirectToAction("thanks");
            }
            return View(appointments);
        }
        public ActionResult thanks()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Appointment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Appointment([Bind(Include = "id,appDate,reason")]Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointments);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(appointments);
        }
        // GET: Patients/cancelAppointment/5
        public ActionResult cancelAppointment(int? id)
        {
            id = db.Appointments.Max(t => t.id);
            Appointments patients = db.Appointments.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/cancelAppointment/5
        [HttpPost, ActionName("cancelAppointment")]
        [ValidateAntiForgeryToken]
        public ActionResult cancelAppointment(int id)
        {
            id = db.Appointments.Max(t => t.id);
            Appointments patients = db.Appointments.Find(id);
            db.Appointments.Remove(patients);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult viewDiseases()
        {
            return View(db.Diseases.ToList());
        }
        [HttpPost]
        public ActionResult viewDiseases(string searchString)
        {
            var diseases = from pl in db.Diseases
                               select pl;
            if (!String.IsNullOrEmpty(searchString))
            {
                diseases = diseases.Where(s => s.name.Contains(searchString));
            }
            return View(diseases);
        }
        [HttpGet]
        public ActionResult connectDoctor()
        {
            return View(db.Doctors.ToList());
        }
        [HttpPost]
        public ActionResult connectDoctor(string searchString)
        {
            var doctors = from pl in db.Doctors
                           select pl;
            if (!String.IsNullOrEmpty(searchString))
            {
                doctors = doctors.Where(s => s.name.Contains(searchString));
            }
            return View(doctors);
        }
        public ActionResult profileSettings()
        {
            return View(db.profile.ToList());
        }
        [HttpGet]
        public ActionResult patientProfile()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult patientProfile([Bind(Include = "id,name,symptoms,phNo")]patientsProfile dataSet)
        {
            if (ModelState.IsValid)
            {
                db.profile.Add(dataSet);
                db.SaveChanges();
                return RedirectToAction("profileSettings");
            }

            return View(dataSet);
        }
        // GET: Patients/editProfile/5
        public ActionResult editProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patientsProfile patients = db.profile.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/editProfile/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editProfile([Bind(Include = "id,name,paitientNo,symptoms,phNo")] patientsProfile patients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patients);
        }
        public ActionResult diseaseDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diseaseData patients = db.Diseases.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }
        // GET: Patients/Delete/5
        public ActionResult deleteProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patientsProfile patients = db.profile.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("deleteProfile")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteProfile(int id)
        {
            patientsProfile patients = db.profile.Find(id);
            db.profile.Remove(patients);
            db.SaveChanges();
            return RedirectToAction("profileSettings");
        }
        #endregion

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patientsProfile patients = db.profile.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,paitientNo,symptoms,phNo")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                patients.patientNo = getUID();
                db.Patients.Add(patients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patients);
        }

        private long getUID()
        {
            var id = new Patients().id;
            var random = Math.Asin(635)*id;
            return (Int64)random;
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,paitientNo,symptoms,phNo")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                patients.patientNo = getUID();
                db.Entry(patients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patients);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patients patients = db.Patients.Find(id);
            db.Patients.Remove(patients);
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
