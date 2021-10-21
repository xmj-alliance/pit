namespace MongoDataAccess.App.Models;

public interface IBaseModel: IBaseEntity
{
    string DBName { get; }
    string Name { get; }
    string Description { get; }
}