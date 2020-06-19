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
           

            if (_context.Volunteer.Where(v => v.IdVolunteer == request.IdVolunteer).Count() != 1)
                throw new NoSuchVolunteerException("No volunteer with id " + request.IdVolunteer + " found");

           var res =  _context.Volunteer_Pet.Where(v_p => v_p.IdVolunteer == request.IdVolunteer 
           &&((v_p.DateAccepted.Year > request.Year) ||(request.Year == 0))
           ).Join(_context.Pet,
                v_p => v_p.IdPet,
                pet => pet.IdPet,
                (v_p, pet) => new PetResponse
                {
                    IdPet = pet.IdPet,
                    IdBreedType = pet.IdBreedType,
                    IsMale = pet.IsMale,
                    DateAdopted = pet.DateAdopted,
                    Name = pet.Name,
                    ApprocimateDateOfBirth = pet.ApprocimateDateOfBirth,
                    DateRegistred = pet.DateRegistred,
                    Age = DateTime.Now.Year - pet.ApprocimateDateOfBirth.Year
                }).ToList();

            return new GetPetsResponse() { Pets = res};
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
