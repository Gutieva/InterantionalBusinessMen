using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterantionalBusinessMen.Models
{
    public class Executive
    {
        public string ID { get; set; }
        public string Rates { get; set; }
        public string Transaction { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Secret { get; set; }
        public virtual ICollection<Grade> Enrollments { get; set; }
    }
}