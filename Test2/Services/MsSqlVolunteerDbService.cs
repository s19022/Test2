using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.DTOs.Request;
using Test2.DTOs.Response;
using Test2.Exceptions;
using Test2.Models;

namespace Test2.Services
{
    public class MsSqlVolunteerDbService : IVolunteerDbService
    {
        private readonly MyContext _context;

        public MsSqlVolunteerDbService(MyContext context)
        {
            _context = context;
        }

        public GetPetsResponse GetPets(GetPetsRequest request)
        {
            var response = new GetPetsResponse()
            {
                Pets = new List<PetResponse>()
            };

            if (_context.Volunteer.Where(v => v.IdVolunteer == request.IdVolunteer).Count() != 1)
                throw new NoSuchVolunteerException("No volunteer with id " + request.IdVolunteer + " found");

            _context.Volunteer.Join(_context.Volunteer_Pet,
                vol => vol.IdVolunteer,
                vol_pet => vol_pet.IdVolunteer,
                (vol, vol_pet) => new { vol.IdVolunteer, vol_pet.IdPet});

            return response;
        }

        public void AssignPetToVolunteer(AssignPetRequest request)
        {
            if (_context.Volunteer.Where(v => v.IdVolunteer == request.IdVolunteer).Count() != 1)
                throw new NoSuchVolunteerException("No volunteer with id " + request.IdVolunteer + " found");

            if (_context.Pet.Where(pet => pet.IdPet == request.IdPet).Count() != 1)
                throw new NoSuchPetException("No pet with id " + request.IdVolunteer + " found");

            if (_context.Volunteer.Where(v => v.IdVolunteer == request.IdVolunteer && v.IdSupervisor == null).Count() != 1)
                throw new VolunteerAlreadyHasSupervisporException("Volunteer with id " + request.IdVolunteer + " Already Has Supervispor");

            using(var trans = _context.Database.BeginTransaction())
            {
                Volunteer_Pet volunteer_Pet = new Volunteer_Pet() { 
                    IdPet = request.IdPet,
                    IdVolunteer = request.IdVolunteer,
                    DateAccepted = DateTime.Now
                };

                _context.Add<Volunteer_Pet>(volunteer_Pet);

                _context.SaveChanges();

                trans.Commit();
            }

        }
    }
}
