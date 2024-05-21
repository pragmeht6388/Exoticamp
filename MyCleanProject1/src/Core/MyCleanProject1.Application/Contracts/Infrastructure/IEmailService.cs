using MyCleanProject1.Application.Models.Mail;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
