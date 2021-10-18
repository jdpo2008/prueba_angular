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
    public class AlumnoController : ApiBaseController
    {
        private readonly IAlumnoRepositorio _IAlumnoRepositorio;
        private readonly ICursoRepositorio _ICursoRepositorio;
        private readonly INotasAlumnosRepositorio _INotasAlumnosRepositorio;

        public AlumnoController(IAlumnoRepositorio IAlumnoRepositorio, ICursoRepositorio ICursoRepositorio, INotasAlumnosRepositorio INotasAlumnosRepositorio)
        {
            _IAlumnoRepositorio = IAlumnoRepositorio;
            _ICursoRepositorio = ICursoRepositorio;
            _INotasAlumnosRepositorio = INotasAlumnosRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _IAlumnoRepositorio.ObtenerAlumnos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _IAlumnoRepositorio.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlumnoDtoRequest request)
        {
            var alumnoDb = await _IAlumnoRepositorio.ObtenerAlumnoByDni(request.Dni);

            if(alumnoDb != null) 
            { 
                return CreatedAtAction(nameof(Post), false);
            }

            Alumno alumno = new Alumno
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Sexo = request.Sexo,
                Dni = request.Dni,
                Email = request.Email,
                FechaNacimiento = request.FechaNacimiento,
                Edad = request.Edad,
            };

            if(request.NotasAlumno.Count > 0)
            {
                foreach (var item in request.NotasAlumno)
                {
                    Curso curso = new Curso();
                    curso = await _ICursoRepositorio.GetById(item.CursoId);
                    alumno.Cursos.Add(curso);

                    NotasAlumno nota = new NotasAlumno { 
                        AlumnoId = item.AlumnoId,
                        CursoId = item.CursoId,
                        Parcial = item.Parcial,
                        PromedioParcial = item.PromedioParcial,
                        Practicas = item.Practicas,
                        PromedioPracticas = item.PromedioPracticas,
                        Final = item.Final,
                        PromedioFinal = item.PromedioFinal
                    };

                    alumno.NotasAlumno.Add(nota);

                    await _INotasAlumnosRepositorio.Add(nota);
                }

            }

            var response = await _IAlumnoRepositorio.Add(alumno);

            return CreatedAtAction(nameof(Post), response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] AlumnoDtoRequest request, Guid id)
        {
            Alumno alumno = await _IAlumnoRepositorio.GetById(id);

            alumno.Nombres = request.Nombres;
            alumno.Apellidos = request.Apellidos;
            alumno.Email = request.Email;
            alumno.Dni = request.Dni;
            alumno.Edad = request.Edad;
            alumno.Sexo = request.Sexo;

            if (request.NotasAlumno.Count > 0)
            {
                foreach (var item in request.NotasAlumno)
                {
                    var notaBd = _INotasAlumnosRepositorio.GetById(item.Id);

                    if(notaBd == null) 
                    {
                        Curso curso = new Curso();
                        curso = await _ICursoRepositorio.GetById(item.CursoId);
                        alumno.Cursos.Add(curso);

                        NotasAlumno nota = new NotasAlumno
                        {
                            AlumnoId = item.AlumnoId,
                            CursoId = item.CursoId,
                            Parcial = item.Parcial,
                            PromedioParcial = item.PromedioParcial,
                            Practicas = item.Practicas,
                            PromedioPracticas = item.PromedioPracticas,
                            Final = item.Final,
                            PromedioFinal = item.PromedioFinal
                        };

                        alumno.NotasAlumno.Add(nota);

                        await _INotasAlumnosRepositorio.Add(nota);
                    } else
                    {
                        NotasAlumno nota = new NotasAlumno
                        {
                            Id = item.Id,
                            AlumnoId = item.AlumnoId,
                            CursoId = item.CursoId,
                            Parcial = item.Parcial,
                            PromedioParcial = item.PromedioParcial,
                            Practicas = item.Practicas,
                            PromedioPracticas = item.PromedioPracticas,
                            Final = item.Final,
                            PromedioFinal = item.PromedioFinal
                        };

                        await _INotasAlumnosRepositorio.Update(nota);
                    }
                   
                }

            }

            await _IAlumnoRepositorio.Update(alumno);

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Alumno alumno = await _IAlumnoRepositorio.GetById(id);

            if (alumno == null)
            {
                return Ok(false);
            }

            await _IAlumnoRepositorio.Remove(alumno);

            return Ok(true);
        }
    }
}
