using Workaholic.CategoryService.Repository.MongoDB;
using Workaholic.CategoryService.Repository.MongoDB.Abstract;
using Workaholic.CategoryService.Repository.MongoDB.Interfaces;
using Workaholic.CategoryService.Repository.MongoDB.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepositoryBase<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.Configure<MongoSettings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("MongoDb:MongoConnection").Value;
    options.Database = builder.Configuration.GetSection("MongoDb:Database").Value;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();