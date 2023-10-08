namespace Workaholic.CategoryService.Repository.MongoDB.Models
{
      public class Result
      {
            public Result()
            {
                  Success = true;
            }
            public bool Success { get; set; }
            public string? Messsage { get; set; }
      }
      public class GetOneResult<TEntity> : Result where TEntity : class, new()
      {
            public TEntity? Entity { get; set; }


      }
      public class GetManyResult<TEntity> : Result where TEntity : class, new()
      {
            public IEnumerable<TEntity>? Result { get; set; }


      }
}