using Exoticamp.UI.Models.EventCart;
using Exoticamp.UI.Models.ResponseModels.EventCart;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IEventCartRepository
    {
        Task<CreateEventCartResponseModel> AddEventCart(EventCartVM campsiteVM);
        Task<IEnumerable<EventCartVM>> GetAllEventCart();

        Task<GetEventCartByIdResponseModel> GetEventCartById(string Id);

        //Task<EditCampsiteResponseModel> EditCampsite(CampsiteVM campsiteVM);
        Task<DeleteEventCartResponseModel> DeleteEventCart(string Id);
    }
}
