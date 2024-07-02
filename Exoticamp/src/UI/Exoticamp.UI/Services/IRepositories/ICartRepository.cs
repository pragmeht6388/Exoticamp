using Exoticamp.UI.Models.CampCart;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ICartRepository
    {
        Task<AddCartResponseModel> AddCartCamp(CartCampsite cartCampVM);
        Task<AddCartResponseModel> CartById(string id);
        Task<AddCartResponseModel> DeleteCartId(string id);
        Task<AllCartResponseModel> GetAllCart();

    }
}
