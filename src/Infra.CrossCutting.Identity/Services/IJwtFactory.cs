using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskB3.Infra.CrossCutting.Identity.Services
{
    public interface IJwtFactory
    {
        Task<JwtToken> GenerateJwtToken(ClaimsIdentity claimsIdentity);
    }
}
