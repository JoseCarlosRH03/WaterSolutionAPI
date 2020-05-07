using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterial _material;

        public MaterialController(IMaterial material)
        {
            _material = material;
        }


        [HttpGet]
        [Route("Materiales/{id}")]
        public async Task<List<Material>> Materiales(int id)
        {

            return await _material.Get(id);
        }

    }
}