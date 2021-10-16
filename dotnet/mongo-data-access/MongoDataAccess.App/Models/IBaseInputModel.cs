namespace MongoDataAccess.App.Models;

internal interface IBaseInputModel
{
    string? DBName { get; }
    string? Name { get; }
    string? Description { get; }
}