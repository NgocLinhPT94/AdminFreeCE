using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Data.Database
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; }

        string ProviderName { get; }

        void LoadSettings();

        void WriteSettings(string connectionString, string providerName);
    }
}
