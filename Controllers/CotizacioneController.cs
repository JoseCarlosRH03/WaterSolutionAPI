﻿using System;
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
    public class CotizacioneController : ControllerBase
    {
        private readonly ICotizaciones _cotizacion;

        public CotizacioneController(ICotizaciones cotizacion)
        {
            _cotizacion = cotizacion;
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Post([FromBody] Cotizaciones model)
        {
            if (!ModelState.IsValid) return BadRequest();
      
           var data = await _cotizacion.save(model);

            return Ok(data);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<Cotizaciones>> Put([FromBody] Cotizaciones model)
        {

            try
            {
                await _cotizacion.Edit(model);
            }
            catch (Exception ex)
            {
              return BadRequest();
                
                throw ex;
            }

            return Ok(model);
        }

        public bool Exists(int id)
        {
            return _cotizacion.Exists(id);
        }
    }
}