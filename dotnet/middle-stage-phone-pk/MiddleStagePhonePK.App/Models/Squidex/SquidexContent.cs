namespace MiddleStagePhonePK.App.Models.Squidex;

public record SquidexContent<T>(
    string Id,
    int Version,
    DateTime Created,
    string CreatedBy,
    T? Data
);
