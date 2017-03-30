using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.Site.Database.Tables;

namespace BastardFat.AgileBoard.Site.Database.Controllers
{
    public class UsersDBController : AgileBoardDBController
    {
        public UsersDBController(AgileBoardDBContext database) : base(database) { }

        public IQueryable<User> GetAll() => Database.Users;

        public bool Add(string Name, string EncodedPassword, string RoleName)
        {
            try
            {
                if (Database.Users.Any(u => u.Name == Name)) return false;
                var role = Database.Roles.FirstOrDefault(r => r.RoleName == RoleName);
                if (role == null) return false;
                return Database.TryTransaction(() =>
                    Database.Users.Add(new User() { Name = Name, PasswordHash = EncodedPassword, RoleId = role.Id })
                );
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(string Name)
        {
            try
            {
                if (!Database.Users.Any(u => u.Name == Name)) return false;
                if (Name == "Admin") return false;
                return Database.TryTransaction(() =>
                    Database.Users.Remove(Get(Name))
                );
            }
            catch
            {
                return false;
            }
        }

        public bool ChangePassword(string username, string EncodedPassword)
        {
            try
            {
                User searchResult = Database.Users.FirstOrDefault(user => user.Name == username);
                if (searchResult == null) return false;
                return Database.TryTransaction(() => searchResult.PasswordHash = EncodedPassword);
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeRole(string username, string RoleName)
        {
            try
            {
                User searchResult = Database.Users.FirstOrDefault(user => user.Name == username);
                if (searchResult == null) return false;
                var role = Database.Roles.FirstOrDefault(r => r.RoleName == RoleName);
                if (role == null) return false;
                return Database.TryTransaction(() => searchResult.RoleId = role.Id);
            }
            catch
            {
                return false;
            }
        }

        public User Get(string Name) => Database.Users.FirstOrDefault(u => u.Name == Name);

        public User GetById(int id) => Database.Users.FirstOrDefault(u => u.Id == id);

        public bool CheckLogin(string Name, string EncodedPassword, out User SearchResut)
        {
            SearchResut = Database.Users.FirstOrDefault(u => u.Name == Name && u.PasswordHash == EncodedPassword);
            if (SearchResut == null) return false;
            return true;
        }

    }
}