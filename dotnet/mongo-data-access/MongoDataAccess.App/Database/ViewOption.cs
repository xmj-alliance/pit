namespace MongoDataAccess.App.Database;

public interface IProjectionOption
{
    IEnumerable<string>? Includes { get; }
    IEnumerable<string>? Excludes { get; }
}

public interface IPaginationOption
{
    int? Page { get; }
    int? PerPage { get; }
}

public interface ISortOption
{
    string? OrderBy { get; }
    string? Order { get; }
}

public interface IViewOption : IProjectionOption, IPaginationOption, ISortOption { }

internal record ProjectionOption(
    IEnumerable<string>? Includes = null,
    IEnumerable<string>? Excludes = null
) : IProjectionOption;

internal record PaginationOption(
    int? Page = null,
    int? PerPage = null
) : IPaginationOption;

internal record SortOption(
    string? OrderBy = null,
    string? Order = null
) : ISortOption;

internal record ViewOption(
    IEnumerable<string>? Includes = null,
    IEnumerable<string>? Excludes = null,
    int? Page = null,
    int? PerPage = null,
    string? OrderBy = null,
    string? Order = null
) : IViewOption;
