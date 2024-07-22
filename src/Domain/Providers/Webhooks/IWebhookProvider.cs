using System.Threading.Tasks;

namespace TaskB3.Domain.Providers.Webhooks;

public interface IWebhookProvider
{
    Task Send(string message);
}
