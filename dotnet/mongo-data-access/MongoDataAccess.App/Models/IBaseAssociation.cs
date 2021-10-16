namespace MongoDataAccess.App.Models;

internal interface IBaseAssociation
{
    string ID { get; }
    DateTime UpdateDate { get; }
    DateTime DeleteDate { get; }
}
