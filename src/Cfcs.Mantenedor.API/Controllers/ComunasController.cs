using Cfcs.Mantenedor.API.Abstractions.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cfcs.Mantenedor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunasController : ControllerBase
    {
        IComunasRepository repository;

        public ComunasController(IComunasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{regionCodigo}/{ciudadCodigo}")]
        public IActionResult Get(short regionCodigo, short ciudadCodigo)
        {
            return Ok(repository.Select(regionCodigo, ciudadCodigo));
        }
    }
}
