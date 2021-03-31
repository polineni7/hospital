using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Dispensary
    {
        public int Billno { get; set; }
        public DateTime? Dat { get; set; }
        public int? PatientId { get; set; }
        public double? BillAmt { get; set; }

        public virtual PatientRegistrations Patient { get; set; }
    }
}
