using MiddleStagePhonePK.App.Models;

namespace MiddleStagePhonePK.App.Services;

public interface IPhoneService
{
    Task<List<Phone>> GetByIDs(IEnumerable<string> ids);
}
