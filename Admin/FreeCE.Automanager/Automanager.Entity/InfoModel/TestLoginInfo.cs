using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Entity.InfoModel
{
    public class TestLoginInfo
    {
        //[Required(ErrorMessage = ResourceConstants.Validation.UserNameObligatory)]
        //Co the them message tu day
        public string username { get; set; }

        public string pass { get; set; }
    }
}
