
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterantionalBusinessMen.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public string EnrollmentID { get; set; }
        public string RatesID { get; set; }
        public string TransactionID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Rate Rate { get; set; }
        public virtual Transaction Transaction { get; set; }
        public int ExecutiveID { get; internal set; }
    }
}