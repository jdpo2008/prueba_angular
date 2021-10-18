using AP_Examen.Comun.DTOs;
using AP_Examen.Comun.Interfaces.Repositorios;
using AP_Examen.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Examen.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CursoController : ApiBaseController
    {
        private readonly ICursoRepositorio _ICursoRepositorio;
        public CursoController(ICursoRepositorio ICursoRepositorio)
        {
            _ICursoRepositorio = ICursoRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ICursoRepositorio.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _ICursoRepositorio.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CursoDtoRequest request)
        {
            Curso curso = new Curso
            {
                Nombre =  request.Nombre,
                Descripcion = request.Descripcion,
                Obligatoriedad = request.Obligatoriedad
            };

            var response = await _ICursoRepositorio.Add(curso);

            return CreatedAtAction(nameof(Post), response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CursoDtoRequest request, Guid id)
        {
            Curso curso = await _ICursoRepositorio.GetById(id);

            curso.Nombre = request.Nombre;
            curso.Descripcion = request.Descripcion;
            curso.Obligatoriedad = request.Obligatoriedad;

            await _ICursoRepositorio.Update(curso);

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Curso curso = await _ICursoRepositorio.GetById(id);

            if(curso == null) {
                return Ok(false);
            }

            await _ICursoRepositorio.Remove(curso);

            return Ok(true);
        }
    }
}
