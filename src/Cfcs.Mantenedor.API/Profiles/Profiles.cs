using AutoMapper;
using Cfcs.Mantenedor.API.DTO;
using Cfcs.Mantenedor.API.Model;

namespace Cfcs.Mantenedor.API.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreatePersonaRequestDTO, Persona>();
            CreateMap<Persona, PersonaResponseDTO>();
            CreateMap<UpdatePersonaRequestDTO, Persona>();
            CreateMap<Sexo, SexoResponseDTO>();
        }

    }
}
