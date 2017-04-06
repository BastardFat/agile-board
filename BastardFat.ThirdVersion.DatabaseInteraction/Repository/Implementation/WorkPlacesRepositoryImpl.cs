using BastardFat.ThirdVersion.DatabaseInteraction.Context;
using BastardFat.ThirdVersion.DatabaseInteraction.Repository.Base;
using BastardFat.ThirdVersion.DatabaseInteraction.Repository.Interface;
using BastardFat.ThirdVersion.Models.Database;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Repository.Implementation
{
    public class WorkPlacesRepositoryImpl : BaseRepository<WorkPlace, MainDbContext>, IWorkPlacesRepository
    {
        public WorkPlacesRepositoryImpl(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}