using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.Site.Support;

namespace BastardFat.AgileBoard.Site.Database
{
    public class AgileBoardDBInitializer : DropCreateDatabaseIfModelChanges<AgileBoardDBContext>
    {
        protected override void Seed(AgileBoardDBContext context)
        {
            context.TryTransaction(() =>
            {
                context.Roles.Add(new Tables.Role()
                {
                    RoleName = "Admin",
                    IsAdmin = true,
                });
                context.Roles.Add(new Tables.Role()
                {
                    RoleName = "User",
                    IsAdmin = false,
                });
            });

            context.TryTransaction(() =>
            {
                context.Users.Add(new Tables.User()
                {
                    Name = "Admin",
                    PasswordHash = CryptHelper.SHA1("Admin"),
                    RoleId = context.Roles.FirstOrDefault(r => r.RoleName == "Admin").Id,
                });
            });
        }
    }
}