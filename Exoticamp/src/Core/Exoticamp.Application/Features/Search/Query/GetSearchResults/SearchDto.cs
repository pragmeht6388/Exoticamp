using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Search.Query.GetSearchResults
{
    public  class SearchDto
    {
        public IEnumerable<Exoticamp.Domain.Entities.CampsiteDetails> Campsites { get; set; }

        public IEnumerable<Exoticamp.Domain.Entities.Event> Events { get; set; }
        public IEnumerable<Exoticamp.Domain.Entities.Activities> Activities { get; set; }

    }
}
