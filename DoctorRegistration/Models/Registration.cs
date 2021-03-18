using System;

namespace DoctorRegistration.Models
{
    public class Registration : Entity
    {
        public Guid ClientId {get;set;}
        public string Time {get;set;}
    }
}
