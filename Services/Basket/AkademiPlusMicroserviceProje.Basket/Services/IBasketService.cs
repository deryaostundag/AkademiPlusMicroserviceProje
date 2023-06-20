using AkademiPlusMicroserviceProje.Basket.Dtos;
using AkademiPlusMicroserviceProje.Shared.DTOS;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string UserID);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string UserID);
    }
}
