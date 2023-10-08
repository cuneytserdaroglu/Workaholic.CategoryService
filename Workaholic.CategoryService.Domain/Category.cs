using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Workaholic.CategoryService.Domain;

public class Category
{
    public Category()
    {
        SubCategories = new List<SubCategory>();
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("CreatedDate")]
    public DateTime CreatedDate { get; set; }
    [BsonElement("UpdatedDate")]
    public DateTime UpdatedDate { get; set; }
    [BsonElement("IsActive")]
    public bool IsActive { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
    [BsonElement("SubCategories")]
    public virtual List<SubCategory> SubCategories { get; set; }
}