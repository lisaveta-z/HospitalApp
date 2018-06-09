using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Visits = new List<Visit>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
        public string PolicyNumber { get; set; }
        public string Passport { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}
