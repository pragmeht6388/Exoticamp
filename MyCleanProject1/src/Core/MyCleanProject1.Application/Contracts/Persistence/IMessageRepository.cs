using MyCleanProject1.Domain.Entities;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Contracts.Persistence
{
    public interface IMessageRepository : IAsyncRepository<Message>
    {
        public Task<Message> GetMessage(string Code, string Lang);
    }
}
