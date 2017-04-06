using System.Data.Entity;
using System.Threading.Tasks;

namespace BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Interface
{
    public interface IUnitOfWork<out TDbContext> where TDbContext : DbContext
    {
        void Commit();
        Task CommitAsync();
    }
}