using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly UniversityContext universityContext;

        public GenericRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            universityContext.Set<TEntity>().Remove(entity);
            await universityContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await universityContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await universityContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            universityContext.Set<TEntity>().Add(entity);
            await universityContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //universityContext.Entry(entity).State = EntityState.Modified;
            universityContext.Set<TEntity>().AddOrUpdate(entity);
            await universityContext.SaveChangesAsync();
            return entity;
        }
    }
}
