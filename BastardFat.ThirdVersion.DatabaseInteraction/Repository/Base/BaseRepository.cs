using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BastardFat.ThirdVersion.DatabaseInteraction.Factory.Interface;
using BastardFat.ThirdVersion.DatabaseInteraction.Repository.Interface;
using BastardFat.ThirdVersion.Models.Database;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Repository.Base
{
    public class BaseRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : EntityBase, new() where TDbContext : DbContext
    {
        public BaseRepository(IDbContextFactory<TDbContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public TEntity GetById(int id) => Set.FirstOrDefault(x => x.Id == id);


        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Id == id);
        }

        public TEntity Attach(int id)
        {
            return Attach(new TEntity {Id = id});
        }

        public TEntity Attach(TEntity entity)
        {
            var entry = Set.Local.FirstOrDefault(x => x.Id == entity.Id) ?? Set.Attach(entity);
            return entry;
        }


        public TEntity Add(TEntity entity)
        {
            return Set.Add(entity);
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            return Set.AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            Attach(entity);
            var entry = DbContext.Entry(entity);
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
            return entities.Select(Update).ToArray();
        }

        public TEntity AddOrUpdate(TEntity entity)
        {
            return entity.Id == 0 ? Add(entity) : Update(entity);
        }

        public IEnumerable<TEntity> AddOrUpdate(IEnumerable<TEntity> entities)
        {
            return entities.Select(AddOrUpdate).ToArray();
        }

        public TEntity Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
                entity = Delete(entity);
            return Delete(entity);
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                entity = Delete(entity);

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return Set.Remove(entity);
        }

        public IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities)
        {
            return Set.RemoveRange(entities);
        }

        public IQueryable<TEntity> Query()
        {
            return Set;
        }

        protected DbSet<TEntity> Set => DbContext.Set<TEntity>();
        protected DbContext DbContext => DbContextFactory.GetDbContext();

        protected IDbContextFactory<TDbContext> DbContextFactory { get; }
    }
}