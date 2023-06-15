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
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return CreateActionResultInstance(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var products = await _productService.GetByIdAsycn(id);
            return CreateActionResultInstance(products);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var products = await _productService.DeleteAsycn(id);
            return CreateActionResultInstance(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
            var products = await _productService.CreateAsycn(createProductDto);
            return CreateActionResultInstance(products);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var products = await _productService.UpdateAsycnAsync(updateProductDto);
            return CreateActionResultInstance(products);
        }
    }
}
