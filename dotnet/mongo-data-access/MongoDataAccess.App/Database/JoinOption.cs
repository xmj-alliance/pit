namespace MongoDataAccess.App.Database;
public interface ILeftJoinOption
{
    string CollectionName { get; }
    string LocalField { get; }
    string ForeignField { get; }
}

internal record LeftJoinOption(
    string CollectionName,
    string LocalField,
    string ForeignField
) : ILeftJoinOption;
