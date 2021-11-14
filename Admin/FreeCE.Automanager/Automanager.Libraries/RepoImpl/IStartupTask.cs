using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Libraries.RepoImpl
{
    /// <summary>
    ///     Interface which should be implemented by tasks run on startup
    /// </summary>
    public interface IStartupTask
    {
        /// <summary>
        ///     Order
        /// </summary>
        int Order { get; }

        /// <summary>
        ///     Executes a task
        /// </summary>
        void Execute();
    }
}
