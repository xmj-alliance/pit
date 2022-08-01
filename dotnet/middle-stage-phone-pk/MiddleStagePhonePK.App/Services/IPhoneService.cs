using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Models.Squidex;

namespace MiddleStagePhonePK.App.Services;

public interface IPhoneService
{
    Task<List<Phone>> GetByIDs(IEnumerable<string> ids);
    Task<List<Phone>> Add(IEnumerable<SquidexPhoneDataInputDto> newItems);
}
