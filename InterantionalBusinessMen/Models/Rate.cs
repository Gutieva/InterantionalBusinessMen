using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterantionalBusinessMen.Models
{
    public class Rate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RateID { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}