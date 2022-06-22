using Cfcs.Mantenedor.API.Abstractions.Repository;
using Cfcs.Mantenedor.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cfcs.Mantenedor.API.Repository
{
    public class ComunasRepository : IComunasRepository
    {
        MantenedorContext context;
        public ComunasRepository(MantenedorContext context)
        {
            this.context = context;
        }

        public List<Comuna> Select(short regionCodigo, short ciudadCodigo)
        {
            return context.Comunas.Where(comuna =>
                comuna.RegionCodigo == regionCodigo &&
                comuna.CiudadCodigo == ciudadCodigo).ToList();
        }
    }
}
