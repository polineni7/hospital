using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class PatientAdmissions
    {
        public int AdminssionId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Roomno { get; set; }
        public double? DailyAmt { get; set; }
        public int? Pos { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual PatientRegistrations Patient { get; set; }
    }
}
