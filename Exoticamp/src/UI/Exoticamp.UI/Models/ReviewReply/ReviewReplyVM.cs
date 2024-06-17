using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.ReviewReply
{
    public class ReviewReplyVM
    {
        [Key]
        public Guid Id { get; set; }
        public string Reply { get; set; }
        public Guid ReviewId { get; set; }
       // public Guid ReviewsId { get; set; }

        public virtual Domain.Entities.Reviews Reviews { get; set; }
    }
}
