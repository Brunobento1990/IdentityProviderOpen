using static BCrypt.Net.BCrypt;


namespace Appication.Adapters;

public static class SenhaAdapter
{
    public static bool Verificar(string confirmPassword, string password)
    {
        return Verify(confirmPassword, password);
    }

    public static string GerarHash(string password)
    {
        return HashPassword(password, 10);
    }
}