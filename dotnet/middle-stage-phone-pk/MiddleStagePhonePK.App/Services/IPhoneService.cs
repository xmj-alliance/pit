using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Models.Squidex;

namespace MiddleStagePhonePK.App.Services;

public interface IPhoneService
{
    Task<List<Phone>> GetByIDs(IEnumerable<string> ids);
    Task<List<Phone>> Add(IEnumerable<SquidexPhoneDataInputDto> newItems);
    Task<List<Phone>> Update(IDictionary<string, SquidexPhoneDataInputDto> idNewItemMap);
    Task<List<Phone>> Delete(IEnumerable<string> ids);
}
