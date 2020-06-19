using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2.DTOs.Response
{
    public class GetPetsResponse
    {
        public List<PetResponse> Pets { get; set; }
    }
}
