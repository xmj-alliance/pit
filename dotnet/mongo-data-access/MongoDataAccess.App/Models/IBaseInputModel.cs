namespace MongoDataAccess.App.Models;

public interface IBaseInputModel
{
    string? DBName { get; }
    string? Name { get; }
    string? Description { get; }
}