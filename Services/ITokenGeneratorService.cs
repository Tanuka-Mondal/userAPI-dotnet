using UserAPI_Tanuka.Models;

namespace UserAPI_Tanuka.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(int id, string? name, string? role);
    }
}
