using System.Data.Entity;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Factory.Interface
{
    public interface IDbContextFactory<out TDbContext> where TDbContext: DbContext
    {
        TDbContext GetDbContext();
    }
}