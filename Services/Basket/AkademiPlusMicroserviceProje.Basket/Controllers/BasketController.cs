using AkademiPlusMicroserviceProje.Basket.Dtos;
using AkademiPlusMicroserviceProje.Basket.Services;
using AkademiPlusMicroserviceProje.Shared.ControllerBases;
using AkademiPlusMicroserviceProje.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet] 
        public async Task< IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserID));
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            basketDto.UserID = _sharedIdentityService.GetUserID;
            var response = await _basketService.SaveOrUpdate(basketDto);
            return CreateActionResultInstance(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserID));
        }
    }
}
