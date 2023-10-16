using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Common.Helper
{
    public static class DatabaseConnectConfiguration
    {
        public static string ConnectionString()
        {
            string connectionType = string.Empty;
#if DEBUG
            connectionType = "DebugConnection";
#endif
#if RELEASE
            connectionType = "ReleaseConnection";
#endif

            return connectionType;

        }
    }
}
