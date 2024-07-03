using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface ICartCampRepository:IAsyncRepository<CartCamp>
    {
        Task<List<Campsite>> GetAll(bool includePassedEvents);
        Task<CartCamp> Addcart(CartCamp cartCamp);
     
        Task<CartCamp> DeleteCart(CartCamp cartCamp);
    }
}
