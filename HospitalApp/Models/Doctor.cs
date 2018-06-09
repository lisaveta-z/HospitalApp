using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Visits = new List<Visit>();
        }

        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; }
        public ICollection<Visit> Visits { get; set; }
    }
}
