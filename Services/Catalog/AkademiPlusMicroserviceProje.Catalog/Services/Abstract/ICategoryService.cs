using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Shared.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsycn(CreateCategoryDto createCategoryDto);
        Task<Response<CategoryDto>> GetByIdAsycn(string id);
        Task<Response<NoContent>> UpdateAsycnAsync(UpdateCategoryDto updateCategoryDto);
        Task<Response<NoContent>> DeleteAsycn(string id);

    }
}
