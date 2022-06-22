using Cfcs.Mantenedor.API.Abstractions.Repository;
using Cfcs.Mantenedor.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cfcs.Mantenedor.API.Repository
{
    public class CiudadesRepository : ICiudadesRepository
    {
        MantenedorContext context;
        public CiudadesRepository(MantenedorContext context)
        {
            this.context = context;
        }

        public List<Ciudad> Select(short regionCodigo)
        {
            return context.Ciudads.Where(ciudad => ciudad.RegionCodigo == regionCodigo).ToList();
        }
    }
}
