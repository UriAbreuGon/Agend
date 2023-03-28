using Application.Generic.Interfaces;
using AutoMapper;
using Domain.Generic;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Services
{
    public class BaseCrudService<TEntity> : IBaseCrudService<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public BaseCrudService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbSet = dbContext.GetDbSet<TEntity>();
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null) throw new Exception("Error deleting entity.");

            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<TEntity>> Get(int top = 50)
        {
            return await Query().Take(top).ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Query().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            if (id != entity.Id) throw new Exception("Id doesn't match");

            var existingEntity = await GetById(id);

            _mapper.Map(entity, existingEntity);

            _dbSet.Update(existingEntity);

            return existingEntity;
        }
    }
}
