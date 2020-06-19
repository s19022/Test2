using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test2.DTOs.Request;
using Test2.DTOs.Response;
using Test2.Exceptions;
using Test2.Services;

namespace Test2.Controllers
{
    [Route("api/volunteers")]
    [ApiController]
    public class VolounteerController : ControllerBase
    {
        private readonly IVolunteerDbService _dbService;
        public VolounteerController(IVolunteerDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}/pets")]
        public IActionResult GetPets(int id, int year)
        {
            var request = new GetPetsRequest()
            {
                IdVolunteer = id, 
                Year = year
            };
            try
            {
                return Ok(_dbService.GetPets(request));
            }
            catch (NoSuchVolunteerException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/pets")]
        public IActionResult AssignPetToVolunteer(int id, AssignPetRequest request)
        {
            request.IdVolunteer = id;

            try
            {
                _dbService.AssignPetToVolunteer(request);
            }catch(NoSuchVolunteerException ex)
            {
                return BadRequest(ex.Message);    
            }
            catch (NoSuchPetException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (VolunteerAlreadyHasSupervisporException ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok();
        }
    }
}