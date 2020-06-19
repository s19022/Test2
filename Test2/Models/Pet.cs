using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Pet
    { 
        [Key]
        public int IdPet { get; set; }

        public int IdBreedType { get; set; }

        [ForeignKey("IdBreedType")]
        public BreedType BreedType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsMale { get; set; }
        
        public DateTime DateRegistred { get; set; }
        
        public DateTime ApprocimateDateOfBirth { get; set; }
       
        public DateTime? DateAdopted { get; set; }

        public virtual ICollection<Volunteer_Pet> Volunteer_Pet { get; set; }

    }
}
