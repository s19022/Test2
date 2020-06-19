using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.DTOs.Request
{
    public class AssignPetRequest
    {
        public int IdVolunteer { get; set; }
        
        [Required]
        public int IdPet { get; set; }
    }
}
