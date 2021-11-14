using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// EntityModel luu tru thong tin mapping voi db
/// </summary>
namespace Automanager.Entity.EntityModel
{
    public class Test_Login
    {
        public Test_Login()
        {
            username = "";
            pass = "";
        }
        public string username { get; set; }
        public string pass { get; set; }
    }
}
