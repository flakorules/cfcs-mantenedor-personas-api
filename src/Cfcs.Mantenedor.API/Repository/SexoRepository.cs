using AutoMapper;
using Cfcs.Mantenedor.API.Abstractions.Repository;
using Cfcs.Mantenedor.API.DTO;
using Cfcs.Mantenedor.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Cfcs.Mantenedor.API.Repository
{
    public class SexoRepository : ISexoRepository
    {
        readonly MantenedorContext context;
        readonly IMapper mapper;
        public SexoRepository(MantenedorContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<SexoResponseDTO> Select()
        {
            var sexosListado = context.Sexos.ToList();

            return mapper.Map<List<Sexo>, List<SexoResponseDTO>>(sexosListado);
        }
    }
}
