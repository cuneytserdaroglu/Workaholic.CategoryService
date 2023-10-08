using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Workaholic.CategoryService.Domain;

public class SubCategory
{
    [BsonElement("CreatedDate")]
    public DateTime CreatedDate { get; set; }
    [BsonElement("UpdatedDate")]
    public DateTime UpdatedDate { get; set; }
    [BsonElement("IsActive")]
    public bool IsActive { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
}