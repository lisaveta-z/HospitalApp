using System;
using System.Collections.Generic;

namespace HospitalApp.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            Doctors = new List<Doctor>();
        }

        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
