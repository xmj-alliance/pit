namespace MongoDataAccess.App.Models;

internal record Toy(
    string ID,
    string DBName,
    string Name,
    string Description,
    DateTime UpdateDate,
    DateTime DeleteDate,

    bool HasAgeLimit,
    decimal Price
): IBaseModel;