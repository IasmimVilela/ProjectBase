using System.Threading.Tasks;
using Refit;

namespace TaskB3.Domain.Providers.Http
{
    public interface IFooClient
    {
        [Get("/")]
        Task<object> GetAll();
    }
}
