using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Interface;

namespace BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Base
{
    public abstract class UnitOfWorkBase<TDbContext> : IUnitOfWork<TDbContext>
        where TDbContext : DbContext
    {
        protected UnitOfWorkBase(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        protected TDbContext DbContext { get; }
    }
}