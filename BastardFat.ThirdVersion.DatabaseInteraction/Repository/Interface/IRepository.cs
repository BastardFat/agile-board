using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BastardFat.ThirdVersion.Models.Database;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Repository.Interface
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        TEntity Add(TEntity entities);

        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Update(IEnumerable<TEntity> entities);

        TEntity AddOrUpdate(TEntity entity);

        IEnumerable<TEntity> AddOrUpdate(IEnumerable<TEntity> entities);

        TEntity Delete(int id);

        Task<TEntity> DeleteAsync(int id);

        TEntity Delete(TEntity entity);

        IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities);

        IQueryable<TEntity> Query();
    }
}