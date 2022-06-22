using Cfcs.Mantenedor.API.Abstractions.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cfcs.Mantenedor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        ICiudadesRepository repository;
        public CiudadesController(ICiudadesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{regionCodigo}")]
        public IActionResult Get(short regionCodigo)
        {
            return Ok(repository.Select(regionCodigo));
        }


    }
}
