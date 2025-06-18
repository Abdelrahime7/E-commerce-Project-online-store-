using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorAccess
{
    internal static class Utils
    {

      public static string ConnectionString()
        {
            var Confuiguration = new ConfigurationBuilder().AddJsonFile("jsconfig1.json").Build();
            var constr  = Confuiguration.GetSection("Constr").Value!;
            return constr;
        }
    }
}
