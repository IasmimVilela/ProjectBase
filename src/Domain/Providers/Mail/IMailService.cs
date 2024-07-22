using System.Threading.Tasks;

namespace TaskB3.Domain.Providers.Mail
{
    public interface IMailService
    {
        Task Send(MailMessage message);
    }
}
