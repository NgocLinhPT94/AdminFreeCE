using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.RepoInterface.Repository
{
    public interface ILoginRepository
    {
        //12092021: demo ket noi
        int Login(string username, string pass);
    }
}
