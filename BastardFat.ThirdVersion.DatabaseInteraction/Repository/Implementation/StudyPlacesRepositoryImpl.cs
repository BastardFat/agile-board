using System.Data;
using BastardFat.ThirdVersion.DatabaseInteraction.Context;
using BastardFat.ThirdVersion.DatabaseInteraction.Repository.Base;
using BastardFat.ThirdVersion.DatabaseInteraction.Repository.Interface;
using BastardFat.ThirdVersion.Models.Database;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Repository.Implementation
{
    public class StudyPlacesRepositoryImpl : BaseRepository<StudyPlace, MainDbContext>, IStudyPlacesRepository
    {
        public StudyPlacesRepositoryImpl(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}