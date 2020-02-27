using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InterantionalBusinessMen.Models;

namespace InterantionalBusinessMen.DAL
{
    public class GNBInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<GNBContext>
    {
        protected override void Seed(GNBContext context)
        {
            var Executive = new List<Executive>
            {
            new Executive{ID="1",Rates="CAD-USD", Transaction="USD", EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Executive{ID="2",Rates="USD-CAD", Transaction="CAD", EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Executive{ID="3",Rates="CAD-EUR", Transaction="EUR", EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Executive{ID="4",Rates="EUR-CAD", Transaction="AUD", EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Executive{ID="5",Rates="USD-AUD", Transaction="EUR", EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Executive{ID="6",Rates="AUD-USD", Transaction="USD", EnrollmentDate=DateTime.Parse("2005-09-01")},
            };

            Executive.ForEach(s => context.Executives.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{ExecutiveID=1 },
            new Enrollment{ExecutiveID=2},
            new Enrollment{ExecutiveID=3},
            new Enrollment{ExecutiveID=4},
            new Enrollment{ExecutiveID=5},
            new Enrollment{ExecutiveID=6},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}