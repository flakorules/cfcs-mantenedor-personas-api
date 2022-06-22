using Cfcs.Mantenedor.API.Abstractions.Repository;
using Cfcs.Mantenedor.API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cfcs.Mantenedor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        IPersonasRepository repository;

        public PersonasController(IPersonasRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.Select());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(repository.Select(id));
        }


        [HttpPost]
        public IActionResult Post(CreatePersonaRequestDTO persona)
        {
            var newPersona = repository.Create(persona);
            return CreatedAtAction(nameof(GetById), new { id = newPersona.Id }, newPersona);
        }

        [HttpPut]
        public IActionResult Put(UpdatePersonaRequestDTO persona)
        {
            return Ok(repository.Update(persona));
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
