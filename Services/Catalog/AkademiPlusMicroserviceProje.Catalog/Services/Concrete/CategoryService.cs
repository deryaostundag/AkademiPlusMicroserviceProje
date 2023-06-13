using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Catalog.Models;
using AkademiPlusMicroserviceProje.Catalog.Services.Abstract;
using AkademiPlusMicroserviceProje.Catalog.Settings;
using AkademiPlusMicroserviceProje.Shared.DTOS;
using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client=new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = dataBase.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<CategoryDto>> CreateAsycn(CreateCategoryDto createCategoryDto)
        {
            var category= _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsycn(string id)
        {
            var result= await _categoryCollection.DeleteOneAsync(x=>x.CategoryID==id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("ID bulunamadı, lütfen geçerli bir ID giriniz",404);
            }

        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories=await _categoryCollection.Find(category=> true).ToListAsync();
            return Response<List<CategoryDto>>.Success(200,_mapper.Map<List<CategoryDto>>(categories));
        }

        public async Task<Response<CategoryDto>> GetByIdAsycn(string id)
        {
            var category=await _categoryCollection.Find<Category>(x=>x.CategoryID==id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Kategori bulunamadı.", 404);
            }
            else
            {
                return Response<CategoryDto>.Success(200,_mapper.Map<CategoryDto>(category));
            }
        }

        public async Task<Response<NoContent>> UpdateAsycnAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            var result=await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID== updateCategoryDto.CategoryID,category);
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
