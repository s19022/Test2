using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Volunteer_Pet
    {
        
        public int IdVolunteer { get; set; }

        [ForeignKey("IdVolunteer")]
        public Volunteer Volunteer { get; set; }

        public int IdPet { get; set; }

        [ForeignKey("IdPet")]
        public Pet Pet { get; set; }

        public DateTime DateAccepted { get; set; }
    }
}
