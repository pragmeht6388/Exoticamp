namespace Exoticamp.UI.Models.Glamping
{
    public class GlampingVM
    {
        public Guid GlampingId { get; set; }
        public Guid CampsiteId { get; set; }
        
        public string Category { get; set; } // e.g., "2 Person", "4 Person"
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
    }
}
