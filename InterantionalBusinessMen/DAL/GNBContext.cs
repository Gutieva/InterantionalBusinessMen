using InterantionalBusinessMen.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterantionalBusinessMen.DAL
{
    public class GNBContext : DbContext
    {

        public GNBContext() : base("SchoolContext")
        {
        }

        public DbSet<Executive> Executives { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}