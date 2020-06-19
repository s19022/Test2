using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class BreedType
    {
        [Key]
        public int IdBreedType { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
