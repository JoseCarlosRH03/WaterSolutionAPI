﻿using System;
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
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleados _empleados;

        public EmpleadoController(IEmpleados empleados)
        {
            _empleados = empleados;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<IEnumerable<Empleados>> Get()
        {
            return await _empleados.Get();
        }

        // GET: api/Empleado/5
        [HttpGet]
        [Route("ListadoEmpleado")]
        public async Task<List<EmpleadoDTO>> ListadoEmpleado()
        {
            return await _empleados.ListadoEmpleados();
        }

        [HttpGet]
        [Route("FormEmpleados")]
        public async Task<FormEmpleadoDTO> FormEmpleados()
        {
            return await _empleados.FormEMpleado();
        }

        [HttpGet]
        [Route("Login/{usuario}/{password}")]
        public async Task<ActionResult<EmpleadoDTO>> Login(string usuario, string password)
        {
           
            return await _empleados.Longin(usuario, password);
        }

        // POST: api/Empleado
        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Post([FromBody] Empleados model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _empleados.Save(model);

            return Ok();
        }

        // PUT: api/Empleado/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Empleados model)
        {
            if (id != model.IdEmpleado)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _empleados.Edit(model);
                }
                catch (Exception ex)
                {
                    if (!Exist(id))
                    {
                        return BadRequest();
                    }
                    else
                    {
                        throw ex;
                    }

                }
            }

            return Ok();
        }

        bool Exist(int id)
        {
            return _empleados.Exist(id);
        }

        [HttpGet]
        [Route("Brigadistas/{id}")]
        public async Task<List<Empleados>> Brigadistas(int id)
        {
            return await _empleados.MostrarBrigadistas(id);
        }

    }
}