using Application.Generic.Dto;
using Domain.Generic;

namespace Application.Generic.Interfaces;

public interface IBaseCrudHandler<TEntity, TRequestDto, TResponseDto>
       where TResponseDto : BaseDto
       where TEntity : BaseEntity
{
    //Task<IQueryable<TEntity>> Query();
    Task<List<TResponseDto>> Get(int top = 50);
    Task<TResponseDto> GetById(int id);
    Task<TResponseDto> Create(TRequestDto dto);
    Task<TResponseDto> Update(TRequestDto dto);
    Task<TResponseDto> Update(int id, TRequestDto dto);
    Task<bool> Delete(int id);
}
