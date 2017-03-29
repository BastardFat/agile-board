using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.Site.Database.Tables;

namespace BastardFat.AgileBoard.Site.Database.Controllers
{
    public class RolesDBController : AgileBoardDBController {
        public RolesDBController(AgileBoardDBContext database) : base(database) { }

        public IQueryable<Role> GetAll() => Database.Roles;

        public bool Add(Role role)
        {
            try
            {
                if (Database.Roles.Any(r => r.RoleName == role.RoleName)) return false;
                role.Id = default(int); // На всякий очковый
                return Database.TryTransaction(() =>
                    Database.Roles.Add(role)
                );
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string RoleName)
        {
            try
            {
                var role = Database.Roles.FirstOrDefault(r => r.RoleName == RoleName);
                if (role == null) return false;
                return Database.TryTransaction(() =>
                    Database.Roles.Remove(role)
                );
            }
            catch
            {
                return false;
            }
        }

    }
}