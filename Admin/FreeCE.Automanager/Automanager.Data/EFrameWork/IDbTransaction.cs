using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Data.EFrameWork
{
    public interface IDbTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
