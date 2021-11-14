using System;
using System.Data.Entity;
using System.Linq;

namespace Automanager.Data.Database
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(string nameOrConnectionString = "FreeCE_ConnectString") : base(
            nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public bool DatabaseExists()
        {
            return Database.Exists();
        }
        

        void IDatabaseContext.ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery, params object[] parameters)
        {
            if (transactionalBehavior.HasValue)
                Database.ExecuteSqlCommand(transactionalBehavior.Value, sqlQuery, parameters);
            else
                Database.ExecuteSqlCommand(sqlQuery, parameters);
        }

        IDbSet<T> IDatabaseContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}
