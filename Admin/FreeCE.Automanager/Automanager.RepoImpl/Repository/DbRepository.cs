using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Automanager.Libraries.RepoImpl;
using Automanager.RepoImpl.DBContext;
using Automanager.RepoInterface.Repository;

namespace Automanager.RepoImpl.Repository
{
    public class DbRepository : IDbRepository //, IDisposable
    {
        public DbRepository()
        {
            DbContext = EngineContext.Current.Resolve<IDbContext>();

            Database = DbContext.Database;
        }

        public DbRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
            Database = DbContext.Database;
        }

        public IDbContext DbContext { get; }

        public Database Database { get; }

        public List<T> SqlQuery<T>(string sqlQuery, params object[] parameters)
        {
            return DbContext.SqlQuery<T>(sqlQuery, parameters).ToList();
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            return DbContext.IsSqlParameterNull(param);
        }
    }
}
