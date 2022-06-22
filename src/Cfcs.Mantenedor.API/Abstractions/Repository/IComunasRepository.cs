using Cfcs.Mantenedor.API.Model;
using System.Collections.Generic;

namespace Cfcs.Mantenedor.API.Abstractions.Repository
{
    public interface IComunasRepository
    {
        List<Comuna> Select(short regionCodigo, short ciudadCodigo);

    }
}
