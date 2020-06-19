using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Volunteer
    {
        [Key]
        public int IdVoluenteer { get; set; }

        public int? IdSupervisor { get; set; }

        [ForeignKey("IdSupervisor")]
        public Volunteer Supervisor { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime StartingDate { get; set; }

        public ICollection<Volunteer> Volunteers { get; set; }

        public virtual ICollection<Volunteer_Pet> Volunteer_Pet { get; set; }
    }
}
