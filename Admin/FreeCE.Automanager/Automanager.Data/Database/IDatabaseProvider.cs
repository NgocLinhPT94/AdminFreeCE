using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Data.Database
{
    public interface IDatabaseProvider
    {
        IDbConnectionFactory ConnectionFactory { get; }
    }
}
