using System.Data.Entity;
using System.Threading.Tasks;
using BastardFat.ThirdVersion.DatabaseInteraction.Factory.Interface;
using BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Interface;

namespace BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Base
{
    public abstract class UnitOfWorkBase<TDbContext, TDbContextFactory> : IUnitOfWork<TDbContext>
        where TDbContext : DbContext
        where TDbContextFactory: IDbContextFactory<TDbContext>
    {
        protected UnitOfWorkBase(TDbContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        protected TDbContext DbContext => DbContextFactory.GetDbContext();
        protected IDbContextFactory<TDbContext> DbContextFactory { get; }
    }
}