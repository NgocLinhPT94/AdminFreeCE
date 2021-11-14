using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Data.UnitOfWork
{
    /// <summary>
    /// Quản lý các repository và context kết nối đến csdl
    /// Khởi tạo transaction
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
