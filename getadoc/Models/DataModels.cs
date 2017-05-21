using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace getadoc.Models
{
    public enum speciality
    {
        Cardiologist,
        Oncologist,
        Ophthalmologist,
        Dermatologist,
        Gastroenterologist
    }
    public class Doctors
    {
        public int id{ get; set; }
        public string name{ get; set; }
        [Display(Name = "Specialization")]
        public speciality speciality { get; set; }
        public double phoneno { get; set; }
    }
    public class diseaseData
    {
        public int id { get; set; }
        [Display(Name ="Disease Name")]
        public string name{ get; set; }
        [Display(Name = "First Symptom")]
        public string symptom1{ get; set; }
        [Display(Name = "Second Symptom")]
        public string symptom2 { get; set; }
        [Display(Name = "Third Symptom")]
        public string symptom3 { get; set; }
        [Display(Name = "Fourth Symptom")]
        public string symptom4 { get; set; }
    }
    public class Patients
    {
        public int id { get; set; }
        [Display(Name = "Your Name")]
        public string name { get; set; }
        [Display(Name = "Your Symptoms")]
        public string symptoms { get; set; }
        [Display(Name = "Your Unique ID")]
        public Int64 patientNo { get; set; }
    }
    public class Appointments
    {
        public int id { get; set; }
        public DateTime appDate { get; set; }
        public string reason { get; set; }
        public bool availble{ get; set; }
    }
}