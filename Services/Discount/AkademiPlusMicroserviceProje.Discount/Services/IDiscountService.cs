using AkademiPlusMicroserviceProje.Shared.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkademiPlusMicroserviceProje.Discount.Models;

namespace AkademiPlusMicroserviceProje.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<Models.Discount>>> GetAll();
        Task<Response<Models.Discount>> GetByID(int id);
        Task<Response<NoContent>> Save(Models.Discount discount);
        Task<Response<NoContent>> Update(Models.Discount discount);
        Task<Response<NoContent>> Delete(int id);
        Task<Response<Models.Discount>> GetCodeWithUserID(string code,string userId);
    }
}
