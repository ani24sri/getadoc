using System;
using System.ComponentModel.DataAnnotations;
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
        public speciality speciality1 { get; set; }
        public double phoneno { get; set; }
       /* public bool Empty
        {
            get
            {
                return (id == 0 &&
                        string.IsNullOrWhiteSpace(name) &&
                        string.IsNullOrWhiteSpace(speciality) &&
                        double.IsNaN(phoneno));
                }
        }*/

    }
    public class diseaseData
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string symptoms{ get; set; }
    }
    public class Patients
    {
        public int id { get; set; }
        public string name { get; set; }
        public string
    }
}