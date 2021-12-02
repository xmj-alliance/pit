namespace MongoDataAccess.App.Models;

public interface IBaseModel
{
    string ID { get; }
    DateTime UpdateDate { get; }
    DateTime? DeleteDate { get; }
    string DBName { get; }
    string Name { get; }
    string Description { get; }
}