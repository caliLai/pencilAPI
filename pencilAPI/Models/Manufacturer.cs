using MongoDB.Bson.Serialization.Attributes;

namespace pencilAPI.Models;

public class Manufacturer{
	[BsonElement("name")]
	public string Name {get;set;} = null!;
	[BsonElement("country")]
	public string Country {get;set;} = null!;
	[BsonElement("yearFounded")]
	public int ?YearFounded {get;set;}
}