using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Consultations
    {
        public int ConsultationId { get; set; }
        public string DrName { get; set; }
        public DateTime? Dat { get; set; }
        public int? PatiendId { get; set; }
        public double? ConsultationAmt { get; set; }

        public virtual PatientRegistrations Patiend { get; set; }
    }
}
