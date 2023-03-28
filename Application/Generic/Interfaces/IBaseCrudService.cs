using Application.Generic.Dto;
using Domain.Generic;

namespace Application.Generic.Interfaces
{

    public interface IBaseCrudService<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query();
        Task<List<TEntity>> Get(int top = 50);
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task<bool> Delete(int id);
    }
}
