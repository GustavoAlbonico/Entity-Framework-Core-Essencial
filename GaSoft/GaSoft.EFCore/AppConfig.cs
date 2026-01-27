namespace GaSoft.EFCore;

public static class AppConfig
{
    public static string GetConnectionString()
    {
        return "Server=localhost\\SQLEXPRESS;Database=gasoftdatabase;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
