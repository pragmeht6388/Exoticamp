using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.RewiewReply.Query.GetReplyById
{
    public class ReviewReplyVm
    {
        [Key]
        public Guid Id { get; set; }
        public string Reply { get; set; }
        public Guid ReviewId { get; set; }
        public Guid ReviewsId { get; set; }

        public virtual Domain.Entities.Reviews  Reviews { get; set; }
    }
}
