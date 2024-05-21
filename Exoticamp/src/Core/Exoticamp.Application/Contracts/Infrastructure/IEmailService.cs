using Exoticamp.Application.Models.Mail;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
