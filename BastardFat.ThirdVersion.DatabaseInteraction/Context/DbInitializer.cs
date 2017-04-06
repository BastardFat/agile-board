using System.Data.Entity;
using BastardFat.ThirdVersion.Models.Database;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<MainDbContext>
    {
        protected override void Seed(MainDbContext context)
        {
            context.StudyPlaces.Add(new StudyPlace()
            {
                Title = "--nowhere--",
                Description = string.Empty,
            });
            context.WorkPlaces.Add(new WorkPlace()
            {
                Title = "--nowhere--",
                Description = string.Empty,
            });
            context.SaveChanges();
        }
    }
}