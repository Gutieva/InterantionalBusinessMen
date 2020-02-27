using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterantionalBusinessMen.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TransactionID { get; set; }
        public string Sku { get; set; }
        public int Amount { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}