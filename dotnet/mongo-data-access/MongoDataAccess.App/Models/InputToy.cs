internal record InputToy(
    string? DBName,
    string? Name,
    string? Description,

    bool? HasAgeLimit,
    decimal? Price
) : IBaseInputModel;