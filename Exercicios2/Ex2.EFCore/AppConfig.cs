using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.EFCore;

public static class AppConfig
{
    public static string GetConnectionString()
    {
        return "Server=localhost\\SQLEXPRESS;Database=ex2database;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
