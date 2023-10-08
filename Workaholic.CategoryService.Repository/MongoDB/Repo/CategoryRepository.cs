using Microsoft.Extensions.Options;
using Workaholic.CategoryService.Domain;
using Workaholic.CategoryService.Repository.MongoDB.Interfaces;

namespace Workaholic.CategoryService.Repository.MongoDB.Repo;

public class CategoryRepository  : MongoRepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(IOptions<MongoSettings> settings) : base(settings)
    {
    }
}