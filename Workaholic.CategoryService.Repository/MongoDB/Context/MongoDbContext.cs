using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Workaholic.CategoryService.Repository.MongoDB.Context
{
      public class MongoDbContext
      {
            private readonly IMongoDatabase _mongoDb;
            public MongoDbContext(IOptions<MongoSettings> options)
            {
                  var mongoClient = new MongoClient(options.Value.ConnectionString);
                  _mongoDb = mongoClient.GetDatabase(options.Value.Database);

            }

            public IMongoCollection<TEntity> GetCollection<TEntity>()
            {
                  return _mongoDb.GetCollection<TEntity>(typeof(TEntity).Name.Trim() + "s");
            }
            public IMongoDatabase GetDatabase()
            {
                  return _mongoDb;
            }


      }
}