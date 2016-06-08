using System.Threading.Tasks;

namespace AspnetCoreRC2Poc.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
