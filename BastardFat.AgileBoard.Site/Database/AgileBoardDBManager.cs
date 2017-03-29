using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.Site.Database.Controllers;

namespace BastardFat.AgileBoard.Site.Database
{
    public class AgileBoardDBManager : IDisposable
    {
        public AgileBoardDBManager()
        {
            Database = new AgileBoardDBContext();
            UserDBController = new UsersDBController(Database);
            RoleDBController = new RolesDBController(Database);
        }

        public AgileBoardDBContext Database;

        public UsersDBController UserDBController { get; set; }
        public RolesDBController RoleDBController { get; set; }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Database.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion


    }
}