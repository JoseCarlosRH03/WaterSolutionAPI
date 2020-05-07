using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitud _solicitud;

        public SolicitudController(ISolicitud solicitud)
        {
            _solicitud = solicitud;
        }

        // POST: api/Solicitud
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Solicitud model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _solicitud.save(model);

            return Ok(model);
        }

        [HttpGet]
        [Route("MostrarSolicitudes/{id}")]
        public async Task<List<SolicitudDTO>> MostrarSolicitudes(int id)
        {
            return await  _solicitud.MotrarTodo(id);
        }

        [HttpGet]
        [Route("RutaSolicitud/{id}")]
        public async Task<List<SolicitudDTO>> RutaSolicitud(int id)
        {
            return await _solicitud.MostrarSolicitudRuta(id);
        }


        [HttpPost]
        [Route("Sequimiento")]
        public async Task<ActionResult<List<SeguimientosDTO>>> PostSeguimiento([FromBody] Seguimientos model)
        {
            if (!ModelState.IsValid) return BadRequest();

          var segumientos = await _solicitud.saveSeguimiento(model);

            return Ok(segumientos);
        }

        // PUT: api/Solicitud/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]  Solicitud model)
        {
            if (id != model.SolicitudId) return BadRequest();

            try
            {
                await _solicitud.Edit(model);
            }
            catch (Exception ex)
            {
                if (!Exists(id)) return BadRequest();
                throw ex;
            }

            return Ok(model);
        }

        private bool Exists(int id) => _solicitud.Exists(id);

    }
}
