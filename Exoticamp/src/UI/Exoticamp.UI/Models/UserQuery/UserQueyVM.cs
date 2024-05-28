namespace Exoticamp.UI.Models.UserQuery
{
    public class UserQueyVM
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
        public string? Response { get; set; }
    }
}
