using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterSolutionAPI.Models;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.ModelDTO;

namespace WaterSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCotizacionController : ControllerBase
    {
        private readonly IDetalleCotizacion _detalleCotizacion;

        public DetalleCotizacionController(IDetalleCotizacion detalleCotizacion)
        {
            _detalleCotizacion = detalleCotizacion;
        }

        // POST: api/DetalleCotizacion
        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Post([FromBody] List<DetalleCotizacion> model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _detalleCotizacion.save(model);

            return Ok(model);
        }

        // PUT: api/DetalleCotizacion/5
        [HttpPut]
        public async Task<ActionResult> Put( [FromBody]List<DetalleCotizacion> model)
        {
           

            try
            {
                await _detalleCotizacion.Edit(model);
            }
            catch (Exception ex)
            {
               return BadRequest();
                throw ex;
            }
            return Ok(model);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<ActionResult> put([FromBody] List<DetalleCotizacion> model)
        {


            try
            {
                await _detalleCotizacion.Delete(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw ex;
            }
            return Ok(model);
        }


        public bool Exists(int id) => _detalleCotizacion.Exists(id);
       
    }
}
