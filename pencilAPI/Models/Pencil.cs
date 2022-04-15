using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pencilAPI.Models;

public class Pencil
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    [BsonElement("name")]
    public string Name { get; set; } = null!;
	[BsonElement("leadSize")]
	public float LeadSize {get;set;}
	[BsonElement("colour")]
	public string Colour {get;set;} = null!;

    [BsonElement("manufacturer")]
    public Manufacturer Manufacturer {get;set;} = null!;
}