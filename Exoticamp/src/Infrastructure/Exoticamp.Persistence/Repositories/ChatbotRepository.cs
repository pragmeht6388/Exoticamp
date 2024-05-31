using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Persistence.Repositories
{
    public class ChatbotRepository : IChatbotRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public ChatbotRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<ChatbotResponse> GetChatBotResponseList()
        {
            return _dbContext.ChatbotResponses;
        }
    }
}
