using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorRegistration.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
