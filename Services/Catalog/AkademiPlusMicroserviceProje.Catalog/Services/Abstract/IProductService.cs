using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Shared.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> CreateAsycn(CreateProductDto createProductDto);
        Task<Response<ProductDto>> GetByIdAsycn(string id);
        Task<Response<NoContent>> UpdateAsycnAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteAsycn(string id);
    }
}
