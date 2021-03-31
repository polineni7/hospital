using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class PatientRegistrations
    {
        public PatientRegistrations()
        {
            Consultations = new HashSet<Consultations>();
            Dispensary = new HashSet<Dispensary>();
            Labs = new HashSet<Labs>();
            PatientAdmissions = new HashSet<PatientAdmissions>();
            Receipts = new HashSet<Receipts>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Mobilenumber { get; set; }
        public string Addr { get; set; }
        public string City { get; set; }

        public virtual ICollection<Consultations> Consultations { get; set; }
        public virtual ICollection<Dispensary> Dispensary { get; set; }
        public virtual ICollection<Labs> Labs { get; set; }
        public virtual ICollection<PatientAdmissions> PatientAdmissions { get; set; }
        public virtual ICollection<Receipts> Receipts { get; set; }
    }
}
