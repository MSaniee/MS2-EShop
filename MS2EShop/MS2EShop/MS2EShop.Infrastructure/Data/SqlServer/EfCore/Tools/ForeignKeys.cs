using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS2EShop.Infrastructure.Data.SqlServer.EfCore.Tools
{
    public class ForeignKeys
    {
        public static List<string> FKsCascadeDelete { get; set; } = new();
    }
}
