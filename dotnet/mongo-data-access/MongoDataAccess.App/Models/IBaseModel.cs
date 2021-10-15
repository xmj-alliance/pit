internal interface IBaseModel
{
    string ID { get; }
    string DBName { get; }
    string Name { get; }
    string Description { get; }
    DateTime UpdateDate { get; }
    DateTime DeleteDate { get; }
}