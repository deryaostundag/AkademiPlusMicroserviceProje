using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Catalog.Services.Abstract;
using AkademiPlusMicroserviceProje.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(categories);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var categories = await _categoryService.GetByIdAsycn(id);
            return CreateActionResultInstance(categories);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var categories = await _categoryService.DeleteAsycn(id);
            return CreateActionResultInstance(categories);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
        {
            var categories = await _categoryService.CreateAsycn(createCategoryDto);
            return CreateActionResultInstance(categories);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var categories = await _categoryService.UpdateAsycnAsync(updateCategoryDto);
            return CreateActionResultInstance(categories);
        }
    }
}
