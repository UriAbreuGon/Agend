using Application.Person.Dtos;
using AutoMapper;

namespace Application.Person.Mappings
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Domain.Entities.Person, PersonResponseDto>();

            CreateMap<PersonRequestDto, Domain.Entities.Person>();
        }
    }
}
