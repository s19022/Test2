using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.DTOs.Request;
using Test2.DTOs.Response;

namespace Test2.Services
{
    public interface IVolunteerDbService
    {
        public GetPetsResponse GetPets(GetPetsRequest request);

        public void AssignPetToVolunteer(AssignPetRequest request);
    }
}
