using System;

namespace DapperORM.App.Models
{
    public record Record(
        int Id,
        int ReaderID,
        int BookID,
        DateTime StartDate,
        DateTime EndDate,
        DateTime UpdateDate,
        DateTime DeleteDate
    );
}