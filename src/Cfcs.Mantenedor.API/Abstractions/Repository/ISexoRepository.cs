using Cfcs.Mantenedor.API.DTO;
using System.Collections.Generic;

namespace Cfcs.Mantenedor.API.Abstractions.Repository
{
    public interface ISexoRepository
    {
        List<SexoResponseDTO> Select();
    }
}
