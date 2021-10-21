namespace MongoDataAccess.App.Models;
public record InstanceCUDMessage<T>(
    bool OK,
    long NumAffected,
    string Message,
    IEnumerable<T>? Instances
);