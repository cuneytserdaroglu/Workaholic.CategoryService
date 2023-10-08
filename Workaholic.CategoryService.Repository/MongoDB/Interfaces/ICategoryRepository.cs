using Workaholic.CategoryService.Domain;
using Workaholic.CategoryService.Repository.MongoDB.Abstract;

namespace Workaholic.CategoryService.Repository.MongoDB.Interfaces;

public interface ICategoryRepository : IMongoRepository<Category>
{

}