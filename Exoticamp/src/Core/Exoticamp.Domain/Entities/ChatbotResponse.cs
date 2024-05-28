using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class ChatbotResponse
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public string? Response { get; set; }
        public int? ParentId { get; set; }
    }
}
