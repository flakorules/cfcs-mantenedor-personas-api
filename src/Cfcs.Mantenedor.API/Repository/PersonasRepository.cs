using AutoMapper;
using Cfcs.Mantenedor.API.Abstractions.Repository;
using Cfcs.Mantenedor.API.DTO;
using Cfcs.Mantenedor.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cfcs.Mantenedor.API.Repository
{
    public class PersonasRepository : IPersonasRepository
    {
        MantenedorContext context;
        IMapper mapper;

        public PersonasRepository(MantenedorContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Persona Create(CreatePersonaRequestDTO personaRequest)
        {
            var personaToCreate = mapper.Map<Persona>(personaRequest);

            personaToCreate.Id = Guid.NewGuid();
            personaToCreate.Nombre = $"{personaRequest.ApellidoPaterno} {personaRequest.ApellidoPaterno}, ${personaRequest.Nombres}";

            string[] rutArr = personaRequest.Run.Split('-');
            personaToCreate.RunCuerpo = int.Parse(rutArr[0].Replace(".", ""));
            personaToCreate.RunDigito = rutArr[1];

            context.Personas.Add(personaToCreate);
            context.SaveChanges();
            return personaToCreate;
        }

        public bool Delete(Guid id)
        {
            var foundPersona = context.Personas.Where(p => p.Id == id).FirstOrDefault();

            if (foundPersona == null)
                return false;

            context.Personas.Remove(foundPersona);

            return context.SaveChanges() > 0;
        }

        public List<Persona> Select()
        {
            return context.Personas.ToList();
        }

        public PersonaResponseDTO Select(Guid id)
        {
            var foundPersona = context.Personas.Where(persona => persona.Id == id).FirstOrDefault();

            if (foundPersona != null)
            {
                return mapper.Map<PersonaResponseDTO>(foundPersona);
            }

            return null;

        }

        public Persona Update(UpdatePersonaRequestDTO persona)
        {
            var personaToUpdate = mapper.Map<Persona>(persona);

            if (personaToUpdate != null)
            {
                personaToUpdate = mapper.Map<Persona>(persona);

                personaToUpdate.Nombre = $"{persona.ApellidoPaterno} {persona.ApellidoPaterno}, {persona.Nombres}";

                string[] rutArr = persona.Run.Split('-');
                personaToUpdate.RunCuerpo = int.Parse(rutArr[0].Replace(".", ""));
                personaToUpdate.RunDigito = rutArr[1];

                context.Personas.Update(personaToUpdate);

                return context.SaveChanges() > 0 ? personaToUpdate : null;
            }

            return null;


        }
    }
}
