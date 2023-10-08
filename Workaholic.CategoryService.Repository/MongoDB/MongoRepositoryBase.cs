using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Workaholic.CategoryService.Repository.MongoDB.Abstract;
using Workaholic.CategoryService.Repository.MongoDB.Context;
using Workaholic.CategoryService.Repository.MongoDB.Models;

namespace Workaholic.CategoryService.Repository.MongoDB
{
      public class MongoRepositoryBase<TEntity> : IMongoRepository<TEntity> where TEntity : class, new()
      {
            private readonly MongoDbContext _context;
            private readonly IMongoCollection<TEntity> _collection;

            public MongoRepositoryBase(IOptions<MongoSettings> settings)
            {
                  _context = new MongoDbContext(settings);
                  _collection = _context.GetCollection<TEntity>();
            }

            public GetManyResult<TEntity> AsQueryable()
            {
                  var result = new GetManyResult<TEntity>();
                  try
                  {
                        var data = _collection.AsQueryable().ToList();
                        if (data != null)
                        {
                              result.Result = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Result = null;
                        throw;
                  }
                  return result;
            }
            public async Task<GetManyResult<TEntity>> AsQueryableAsync()
            {
                  var result = new GetManyResult<TEntity>();
                  try
                  {
                        var data = await _collection.AsQueryable().ToListAsync();
                        if (data != null)
                        {
                              result.Result = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Result = null;
                        throw;
                  }
                  return result;
            }

            public GetOneResult<TEntity> DeleteById(string id)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var objectID = ObjectId.Parse(id);
                        var filter = Builders<TEntity>.Filter.Eq("_id", objectID);
                        var data = _collection.FindOneAndDelete(filter);

                        if (data != null)
                        {
                              result.Entity = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;
            }

            public async Task<GetOneResult<TEntity>> DeleteByIdAsync(string id)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var objectID = ObjectId.Parse(id);
                        var filter = Builders<TEntity>.Filter.Eq("_id", objectID);
                        var data = await _collection.FindOneAndDeleteAsync(filter);

                        if (data != null)
                        {
                              result.Entity = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;
            }

            public void DeleteMany(Expression<Func<TEntity, bool>> filter)
            {
                  _collection.DeleteMany(filter);
            }

            public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
            {
                  await _collection.DeleteManyAsync(filter);
            }

            public GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var deletedDoc = _collection.FindOneAndDelete(filter);
                        result.Entity = deletedDoc;

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                  }
                  return result;
            }

            public async Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var deletedDoc = await _collection.FindOneAndDeleteAsync(filter);
                        result.Entity = deletedDoc;

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                  }
                  return result;
            }

            public GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
            {
                  var result = new GetManyResult<TEntity>();
                  try
                  {
                        var data = _collection.Find(filter).ToList();
                        if (data != null)
                        {
                              result.Result = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Result = null;
                        throw;
                  }
                  return result;
            }
            public async Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter)
            {
                  var result = new GetManyResult<TEntity>();
                  try
                  {
                        var data = await _collection.Find(filter).ToListAsync();
                        if (data != null)
                        {
                              result.Result = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Result = null;
                        throw;
                  }
                  return result;
            }
            public GetOneResult<TEntity> GetById(string id)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var objectID = ObjectId.Parse(id);
                        var filter = Builders<TEntity>.Filter.Eq("_id", objectID);
                        var data = _collection.Find(filter).FirstOrDefault();

                        if (data != null)
                        {
                              result.Entity = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;

            }
            public async Task<GetOneResult<TEntity>> GetByIdAsync(string id)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var objectID = ObjectId.Parse(id);
                        var filter = Builders<TEntity>.Filter.Eq("_id", objectID);
                        var data = await _collection.Find(filter).FirstOrDefaultAsync();

                        if (data != null)
                        {
                              result.Entity = data;
                        }

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;
            }
            public GetManyResult<TEntity> InsertMany(List<TEntity> entities)
            {
                  var result = new GetManyResult<TEntity>();
                  try
                  {

                        _collection.InsertMany(entities);
                        result.Result = entities;

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Result = null;
                        throw;
                  }
                  return result;
            }
            public async Task<GetManyResult<TEntity>> InsertManyAsync(List<TEntity> entities)
            {
                  var result = new GetManyResult<TEntity>();
                  try
                  {
                        await _collection.InsertManyAsync(entities);
                        result.Result = entities;

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Result = null;
                        throw;
                  }
                  return result;
            }
            public GetOneResult<TEntity> InsertOne(TEntity entity)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {

                        _collection.InsertOne(entity);
                        result.Entity = entity;

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;

            }
            public async Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        await _collection.InsertOneAsync(entity);
                        result.Entity = entity;
                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;
            }
            public GetOneResult<TEntity> ReplaceOne(TEntity entity, string id)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var objectID = ObjectId.Parse(id);
                        var filter = Builders<TEntity>.Filter.Eq("_id", objectID);
                        var data = _collection.ReplaceOne(filter, entity);
                        result.Entity = entity;

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;
            }
            public async Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, string id)
            {
                  var result = new GetOneResult<TEntity>();
                  try
                  {
                        var objectID = ObjectId.Parse(id);
                        var filter = Builders<TEntity>.Filter.Eq("_id", objectID);
                        var data = await _collection.ReplaceOneAsync(filter, entity);
                        result.Entity = entity;

                  }
                  catch (System.Exception Exception)
                  {
                        result.Messsage = Exception.Message;
                        result.Success = false;
                        result.Entity = null;
                        throw;
                  }
                  return result;
            }
      }
}