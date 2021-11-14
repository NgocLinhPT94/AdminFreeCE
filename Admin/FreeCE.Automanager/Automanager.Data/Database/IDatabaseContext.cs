using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Automanager.Data.Database
{
    public interface IDatabaseContext
    {
        System.Data.Entity.Database  Database{ get; }
        //Creates a DbSet<TEntity> that can be used to query and save instances of TEntity.
        IDbSet<T> Set<T>() where T : BaseEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionalBehavior"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="parameters"></param>
        void ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery, params object[] parameters);

        //Executes INSERT, UPDATE and DELETE commands to the database for the entities with Added, Modified and Deleted state.
        int SaveChanges();

        bool DatabaseExists();
    }
}
