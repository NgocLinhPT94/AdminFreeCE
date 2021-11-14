using Automanager.Data.Database;
using Automanager.Entity.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.RepoImpl.DBContext
{
    public interface IDbContext
    {
        Database Database { get; }

        IDbSet<T> Set<T>() where T : BaseEntity;

        DbRawSqlQuery<T> SqlQuery<T>(string sqlQuery, params object[] parameters);

        void ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery, params object[] parameters);

        int SaveChanges();

        bool DatabaseExists();

        bool IsSqlParameterNull(SqlParameter param);
        #region TODO: khai bao properties cua du an
        DbSet<Test_Login> Test_Logins { get; set; }
        #endregion
    }
}
