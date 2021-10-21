using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.App.Models;

public record Toy(
    [property:BsonId]
    [property:BsonRepresentation(BsonType.ObjectId)]
    string ID,

    [property:BsonElement("dbname")]
    string DBName,

    [property:BsonElement("name")]
    string Name,

    [property:BsonElement("description")]
    string Description,

    [property:BsonElement("updateDate")]
    DateTime UpdateDate,

    [property:BsonElement("deleteDate")]
    DateTime? DeleteDate,

    [property:BsonElement("hasAgeLimit")]
    bool HasAgeLimit,

    [property:BsonElement("price")]
    decimal Price

): IBaseModel;