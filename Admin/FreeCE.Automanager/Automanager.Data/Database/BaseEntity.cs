using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Data.Database
{
    public abstract class BaseEntity
    {
        /// <summary>
        ///     The Id of the entity
        /// </summary>
        public int Id { get; set; }
    }
}
