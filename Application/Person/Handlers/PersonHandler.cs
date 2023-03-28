using Application.Generic.Handlers;
using Application.Generic.Interfaces;
using Application.Interfaces;
using Application.Person.Dtos;
using AutoMapper;

namespace Application.Person.Handlers
{
    public interface IPersonHandler : IBaseCrudHandler<Domain.Entities.Person, PersonRequestDto, PersonResponseDto>
    {
        new Task<PersonResponseDto> GetById(int id);
        new Task<List<PersonResponseDto>> Get(int top = 50); 
        new Task<PersonResponseDto> Update(PersonRequestDto dto);
        new Task<PersonResponseDto> Update(int id, PersonRequestDto dto);
        new Task<PersonResponseDto> Create(PersonRequestDto dto);
    }

    public class PersonHandler : BaseCrudHandler <Domain.Entities.Person, PersonRequestDto, PersonResponseDto>, IPersonHandler
    {
        public PersonHandler(IPersonService personService, IMapper mapper) : base(personService, mapper)
        {
        }

        public new async Task<PersonResponseDto> GetById(int id)
        {
            return await base.GetById(id);
        }
        public new async Task<List<PersonResponseDto>> Get(int top = 50)
        {
            return await base.Get(top);
        }
        public new async Task<PersonResponseDto> Update(PersonRequestDto dto)
        {
            return await base.Update(dto);
        }
        public new async Task<PersonResponseDto> Update(int id, PersonRequestDto dto)
        {
            return await base.Update(id, dto);
        }
        public new async Task<PersonResponseDto> Create(PersonRequestDto dto)
        {
            return await base.Create(dto);
        }
    }

}
