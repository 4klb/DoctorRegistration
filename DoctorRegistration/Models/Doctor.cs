using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorRegistration.Models
{
    public class Doctor : Entity
    {
        public string FullName { get; set; }

        public ICollection<MedicalPractice> MedicalPractice;
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public Guid ScheduleId { get; set; }
    }
}
