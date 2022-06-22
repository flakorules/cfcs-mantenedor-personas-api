using Cfcs.Mantenedor.API.Model;
using System.Collections.Generic;

namespace Cfcs.Mantenedor.API.Abstractions.Repository
{
    public interface IRegionesRepository
    {
        List<Region> Select();
    }
}
