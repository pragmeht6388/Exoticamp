namespace Exoticamp.UI.Models.Search
{
    public class SearchDto
    {
        public IEnumerable<Exoticamp.Domain.Entities.CampsiteDetails> Campsites { get; set; }

        public IEnumerable<Exoticamp.Domain.Entities.Event> Events { get; set; }
        public IEnumerable<Exoticamp.Domain.Entities.Activities> Activities { get; set; }
    }
}
