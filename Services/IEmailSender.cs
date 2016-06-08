using System.Threading.Tasks;

namespace AspnetCoreRC2Poc.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
