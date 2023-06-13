using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Catalog.Models;
using AkademiPlusMicroserviceProje.Catalog.Services.Abstract;
using AkademiPlusMicroserviceProje.Catalog.Settings;
using AkademiPlusMicroserviceProje.Shared.DTOS;
using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = dataBase.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productCollection=dataBase.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<ProductDto>> CreateAsycn(CreateProductDto createProductDto)
        {
            var product= _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(product);
            return Response<ProductDto>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsycn(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.ProductID == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("ID bulunamadı, lütfen geçerli bir ID giriniz", 404);
            }

        }

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productCollection.Find(category => true).ToListAsync();
            return Response<List<ProductDto>>.Success(200, _mapper.Map<List<ProductDto>>(products));
        }

        public async Task<Response<ProductDto>> GetByIdAsycn(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return Response<ProductDto>.Fail("Kategori bulunamadı.", 404);
            }
            else
            {
                return Response<ProductDto>.Success(200, _mapper.Map<ProductDto>(product));
            }
        }

        public async Task<Response<NoContent>> UpdateAsycnAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, product);
            if (result == null)
            {
                return Response<NoContent>.Fail("Kategori bulunamadı.", 404);
            }
            else
            {
                return Response<NoContent>.Success(204);
            }
        }
    }
}
