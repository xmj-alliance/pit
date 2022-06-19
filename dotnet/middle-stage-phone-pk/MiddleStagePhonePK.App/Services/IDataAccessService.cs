using MiddleStagePhonePK.App.Models;

namespace MiddleStagePhonePK.App.Services;

public interface IDataAccessService
{
    Task<QueryTypes> QueryContentsByIDs(string gqlQueryName, IEnumerable<string> ids, string gqlResultSelector);
}
