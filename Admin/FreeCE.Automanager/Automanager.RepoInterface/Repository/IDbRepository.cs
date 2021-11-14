using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.RepoInterface.Repository
{
    public interface IDbRepository
    {
        List<T> SqlQuery<T>(string sqlQuery, params object[] parameters);
    }
}
