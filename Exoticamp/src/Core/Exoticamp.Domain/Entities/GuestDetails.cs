using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public  class GuestDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long MobileNo {  get; set; }
        public string Gender { get; set; }
        public string FoodPreference {  get; set; }
        public string? SpecialRequest {  get; set; }


    }
}
