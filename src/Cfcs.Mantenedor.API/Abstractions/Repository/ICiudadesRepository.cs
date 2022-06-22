using Cfcs.Mantenedor.API.Model;
using System.Collections.Generic;

namespace Cfcs.Mantenedor.API.Abstractions.Repository
{
    public interface ICiudadesRepository
    {
        List<Ciudad> Select(short regionCodigo);
    }
}
