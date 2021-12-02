using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.App.Models;

public record StoredCustomer(
    [property:BsonId]
    [property:BsonRepresentation(BsonType.ObjectId)]
    string ID,

    [property:BsonElement("dbname")]
    string DBName,

    [property:BsonElement("isAdult")]
    bool IsAdult
) : IStoredCustomer;
