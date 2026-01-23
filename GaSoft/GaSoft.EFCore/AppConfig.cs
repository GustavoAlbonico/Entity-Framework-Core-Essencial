namespace GaSoft.EFCore;

public static class AppConfig
{
    public static string GetConnectionString()
    {
        return "Server=localhost;DataBase=gasoftdatabase;Uid=root;Pwd=1234;TrustServerCertificate=True;";
    }
}
