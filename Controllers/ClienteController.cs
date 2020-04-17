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
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }
        
        [HttpGet]
        [Route("MostrarClientes/{id}")]
        public async Task<List<SolicitudDTO>> MostrarClientes(int id)
        {
            return await _cliente.MotrarTodo(id);
        }
      
        // POST: api/Cliente
        [Route("Save")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _cliente.Save(model);

            return Ok(model);
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _cliente.ListaClientes();
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        [Route("Edit")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente model)
        {
            if(id != model.PersonaId)
            {
                return BadRequest();
            }
            try
            {
                await _cliente.Edit(model);
            }
            catch (Exception ex)
            {
                if (!Exists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw ex;
                } 
            }
            return Ok(model);
        }

        bool Exists(int id)
        {
            return _cliente.Exists(id);
        }
    }
}
