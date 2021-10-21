namespace MongoDataAccess.App.Models;

public record CUDMessage(
    bool OK,
    long NumAffected,
    string Message
);