using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Automanager.Data.Database;
using Automanager.Entity.EntityModel;
using Automanager.RepoImpl.MapEntyConfig;

namespace Automanager.RepoImpl.DBContext
{
    /// <summary>
    /// DBContext tổng của hệ thống map tương ứng với DBSet(Entity)
    /// </summary>
    public class FreeCEContext : System.Data.Entity.DbContext, IDbContext
    {
        public DbRawSqlQuery<T> SqlQuery<T>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<T>(sqlQuery, parameters);
        }

        public void ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery,
            params object[] parameters)
        {
            if (transactionalBehavior.HasValue)
                Database.ExecuteSqlCommand(transactionalBehavior.Value, sqlQuery, parameters);
            else
                Database.ExecuteSqlCommand(sqlQuery, parameters);
        }

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public bool DatabaseExists()
        {
            return Database.Exists();
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            if (sqlValue is INullable nullableValue)
                return nullableValue.IsNull;
            return sqlValue == null || sqlValue == DBNull.Value;
        }

        #region Khai bao DbSet<Entity table>
        public DbSet<Test_Login> Test_Logins { get; set; }
        #endregion

        #region Ctors ==> Khai báo khởi tạo DbContext kết nối với DB
        public FreeCEContext()
            : base("Name=FreeCE_ConnectString")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public FreeCEContext(string connectionString)
           : base(connectionString) { }

        public FreeCEContext(string connectionString, DbCompiledModel model)
            : base(connectionString, model) { }

        public FreeCEContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }

        public FreeCEContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection) { }
        #endregion

        #region Phuong thức
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //mapping với folder MapConfig(định nghĩa tên cột giá trị tương ứng table DB)
            modelBuilder.Configurations.Add(new TestLoginConfig());
        }
        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new TestLoginConfig(schema));
            return modelBuilder;
        }
        #endregion
    }
}
