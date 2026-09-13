namespace Applications.Services
{
    public interface IJwtGenerator
    {
        string Generate(string userId, string role);
    }
}
