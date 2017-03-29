using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BastardFat.AgileBoard.Site.Database.Tables;
using Npgsql;

namespace BastardFat.AgileBoard.Site.Database
{
    public class AgileBoardDBContext : DbContext
    {
        static AgileBoardDBContext()
        {
            System.Data.Entity.Database.SetInitializer(new AgileBoardDBInitializer());
        }

        public AgileBoardDBContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public T Transaction<T>(Func<T> func, bool isThrow = false) where T : class
        {
            using (var dbContextTransaction = Database.BeginTransaction())
            {
                try
                {
                    T t = func();

                    SaveChanges();

                    dbContextTransaction.Commit();

                    return t;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();

                    if (!isThrow)
                        return null;

                    throw;
                }
            }
        }

        public bool TryTransaction(Action action)
        {
            using (var dbContextTransaction = Database.BeginTransaction())
            {
                try
                {
                    action();

                    SaveChanges();

                    dbContextTransaction.Commit();
                    return true;
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        class NpgsqlConfiguration : DbConfiguration
        {
            public NpgsqlConfiguration()
            {
                SetProviderServices("Npgsql", NpgsqlServices.Instance);
                SetProviderFactory("Npgsql", NpgsqlFactory.Instance);
                SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
            }
        }

    }
}