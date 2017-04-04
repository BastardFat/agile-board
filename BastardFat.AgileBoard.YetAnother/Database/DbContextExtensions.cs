using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.YetAnother.Database
{
    public static class DbContextExtensions
    {
        public static T Transaction<T>(this DbContext DatabaseContext, Func<T> func, bool isThrow = false) where T : class
        {
            using (var dbContextTransaction = DatabaseContext.Database.BeginTransaction())
            {
                try
                {
                    T t = func();

                    DatabaseContext.SaveChanges();

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

        public static bool TryTransaction(this DbContext DatabaseContext, Action action)
        {
            using (var dbContextTransaction = DatabaseContext.Database.BeginTransaction())
            {
                try
                {
                    action();

                    DatabaseContext.SaveChanges();

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
    }
}