using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace getadoc.Models
{
    public class Doctors
    {
        public int id{ get; set; }
        public string name{ get; set; }
        public string speciality { get; set; }
        public double phoneno { get; set; }
    }
    public class diseaseData
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string[] symptoms{ get; set; }
    }
    public class Patients
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}