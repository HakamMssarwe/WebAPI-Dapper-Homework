using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public static class Helper
    {
        public static string GetServerConnectionString(string serverName)
        {
         return ConfigurationManager.ConnectionStrings[serverName].ConnectionString;
        }
    }
}
