using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorRegistration.Models
{
    public class Schedule : Entity
    {
        public string Name { get; set; }
        public DateTime VisitTime { get; set; } 
        public bool IsAvailable { get; set; }
    }
}
