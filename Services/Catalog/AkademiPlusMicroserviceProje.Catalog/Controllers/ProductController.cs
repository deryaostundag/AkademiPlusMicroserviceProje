using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Catalog.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productService.GetAllAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var caregories = await _productService.GetByIdAsycn(id);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var categories = await _productService.DeleteAsycn(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
            var categories = await _productService.CreateAsycn(createProductDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var categories = await _productService.UpdateAsycnAsync(updateProductDto);
            return Ok();
        }
    }
}
