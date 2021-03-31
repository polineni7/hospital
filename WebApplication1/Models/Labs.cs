using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Labs
    {
        public int TestId { get; set; }
        public string Testname { get; set; }
        public DateTime? Dat { get; set; }
        public int? PatientId { get; set; }
        public double? LabAmt { get; set; }

        public virtual PatientRegistrations Patient { get; set; }
    }
}
