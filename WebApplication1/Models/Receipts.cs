using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Receipts
    {
        public int ReceiptNo { get; set; }
        public DateTime? Dat { get; set; }
        public int? PatientId { get; set; }
        public double? Amt { get; set; }

        public virtual PatientRegistrations Patient { get; set; }
    }
}
