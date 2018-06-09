using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  

namespace HospitalApp.Models
{
    public partial class Visit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string DoctorPrescription { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
