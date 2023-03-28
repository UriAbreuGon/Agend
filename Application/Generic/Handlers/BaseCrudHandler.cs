 using Application.Generic.Dto;
using Application.Generic.Interfaces;
using AutoMapper;
using Domain.Generic;

namespace Application.Generic.Handlers
{
    public class BaseCrudHandler<TEntity, TRequestDto, TResponseDto> : IBaseCrudHandler<TEntity, TRequestDto, TResponseDto>
        where TResponseDto : BaseDto
        where TEntity : BaseEntity
    {
        private readonly IBaseCrudService<TEntity> baseCrudService;
        private readonly IMapper mapper;

        public BaseCrudHandler(IBaseCrudService<TEntity> baseCrudService, IMapper mapper)
        {
            this.baseCrudService = baseCrudService;
            this.mapper = mapper;
        }

        //public virtual async Task<IQueryable<TEntity>> Query()
        //{
        //    return await Task.FromResult(this.baseCrudService.Query().AsQueryable());
        //}

        public virtual async Task<List<TResponseDto>> Get(int top = 50)
        {
            var entities = await Task.FromResult(baseCrudService.Query().ToList().Take(top));
            return mapper.Map<List<TResponseDto>>(entities);
        }

        public virtual async Task<TResponseDto> GetById(int id)
        {
            return mapper.Map<TResponseDto>(baseCrudService.GetById(id));
        }

        public virtual async Task<TResponseDto> Create(TRequestDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            entity = await baseCrudService.Create(entity);
            return mapper.Map<TResponseDto>(entity);
        }

        public virtual async Task<TResponseDto> Update(TRequestDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            entity = await baseCrudService.Update(entity);
            return mapper.Map<TResponseDto>(entity);
        }

        public virtual async Task<TResponseDto> Update(int id, TRequestDto dto)
        {
            var BaseEntity = await baseCrudService.GetById(id);
            var entity = mapper.Map<TEntity>(dto);
            entity = await baseCrudService.Update(id, entity);
            return mapper.Map<TResponseDto>(entity);
        }

        public virtual async Task<bool> Delete(int id)
            => await baseCrudService.Delete(id);
    }
}
