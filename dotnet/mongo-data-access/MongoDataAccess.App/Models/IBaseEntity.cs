namespace MongoDataAccess.App.Models;

public interface IBaseEntity
{
    string ID { get; }
    DateTime UpdateDate { get; }
    DateTime? DeleteDate { get; }
}
