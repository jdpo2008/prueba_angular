using AP_Examen.Comun.Interfaces.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Examen.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class NotasAlumnoController : ApiBaseController
    {
        private readonly INotasAlumnosRepositorio _INotasAlumnosRepositorio;

        public NotasAlumnoController(INotasAlumnosRepositorio INotasAlumnosRepositorio)
        {
            _INotasAlumnosRepositorio = INotasAlumnosRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _INotasAlumnosRepositorio.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _INotasAlumnosRepositorio.GetById(id));
        }

    }
}
