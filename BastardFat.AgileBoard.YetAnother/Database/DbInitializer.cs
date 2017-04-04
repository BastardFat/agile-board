using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.YetAnother.Database
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<MainDBContext>
    {
        protected override void Seed(MainDBContext context)
        {
            context.TryTransaction(() =>
            {
                context.StudyPlaces.Add(new Tables.StudyPlace()
                {
                    Title = "--nowhere--",
                    Description = string.Empty,
                });
                context.WorkPlaces.Add(new Tables.WorkPlace()
                {
                    Title = "--nowhere--",
                    Description = string.Empty,
                });
            });
        }
    }
}