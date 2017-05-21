using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using getadoc.Models;
using Microsoft.AspNet.Identity;

namespace getadoc.Models.DbContexts
{
   
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<diseaseData> Diseases { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
    }
   }

