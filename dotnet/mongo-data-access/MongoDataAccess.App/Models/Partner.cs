using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.App.Models;

public record Partner(
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


    [property:BsonElement("type")]
    string Type,

    [property:BsonElement("phone")]
    string Phone,

    [property:BsonElement("address")]
    string Address,

    [property:BsonElement("email")]
    string Email,

    [property:BsonElement("bankAccount")]
    string BankAccount,

    [property:BsonElement("ratings")]
    float Ratings,

    [property:BsonElement("contacts")]
    IEnumerable<string> Contacts
) : IPartner;