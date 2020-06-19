using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.DTOs.Response
{
    public class PetResponse
    {
     
        public int IdPet { get; set; }

        public int IdBreedType { get; set; }


        public string Name { get; set; }

        public bool IsMale { get; set; }

        public DateTime DateRegistred { get; set; }

        public DateTime ApprocimateDateOfBirth { get; set; }

        public DateTime? DateAdopted { get; set; }

        public int Age { get; set; }
    }
}
