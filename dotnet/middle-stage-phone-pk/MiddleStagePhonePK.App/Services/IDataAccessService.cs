using MiddleStagePhonePK.App.Models;

namespace MiddleStagePhonePK.App.Services;

public interface IDataAccessService
{
    Task<List<PhoneQueryContentType>?> QueryContentsByIDs();
}
