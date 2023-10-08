using System.Linq.Expressions;
using Workaholic.CategoryService.Repository.MongoDB.Models;

namespace Workaholic.CategoryService.Repository.MongoDB.Abstract
{
      public interface IMongoRepository<TEntity> where TEntity : class, new()
      {
            GetManyResult<TEntity> AsQueryable();
            Task<GetManyResult<TEntity>> AsQueryableAsync();
            GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
            Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);
            GetOneResult<TEntity> GetById(string id);
            Task<GetOneResult<TEntity>> GetByIdAsync(string id);
            GetOneResult<TEntity> InsertOne(TEntity entity);
            Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity);
            GetManyResult<TEntity> InsertMany(List<TEntity> entities);
            Task<GetManyResult<TEntity>> InsertManyAsync(List<TEntity> entities);
            GetOneResult<TEntity> ReplaceOne(TEntity entity, string id);
            Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id);

            GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);
            Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);
            GetOneResult<TEntity> DeleteById(string id);
            Task<GetOneResult<TEntity>> DeleteByIdAsync(string id);
            void DeleteMany(Expression<Func<TEntity, bool>> filter);
            Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
      }
}