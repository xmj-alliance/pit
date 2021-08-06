using System;

namespace DapperORM.App.Models
{
    public record Book(
        int Id,
        string DBName,
        string Title,
        float Rating,
        DateTime UpdateDate,
        DateTime DeleteDate
    );
}