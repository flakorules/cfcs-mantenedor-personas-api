using Cfcs.Mantenedor.API.Abstractions.Repository;
using Cfcs.Mantenedor.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cfcs.Mantenedor.API.Repository
{
    public class RegionesRepository : IRegionesRepository
    {
        MantenedorContext context;
        public RegionesRepository(MantenedorContext context)
        {
            this.context = context;

        }

        public List<Region> Select()
        {
            return context.Regions.ToList();
        }
    }
}
