using Cfcs.Mantenedor.API.DTO;
using Cfcs.Mantenedor.API.Model;
using System;
using System.Collections.Generic;

namespace Cfcs.Mantenedor.API.Abstractions.Repository
{
    public interface IPersonasRepository
    {
        Persona Create(CreatePersonaRequestDTO persona);
        Persona Update(UpdatePersonaRequestDTO persona);
        bool Delete(Guid id);
        List<Persona> Select();
        PersonaResponseDTO Select(Guid id);

    }
}
