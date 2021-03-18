using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorRegistration.Models
{
    public class Registration : Entity
    {
        public Guid ClientId {get;set;}
        public string Time {get;set;}
    }
}
