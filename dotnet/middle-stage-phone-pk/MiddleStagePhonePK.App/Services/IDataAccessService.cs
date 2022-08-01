using MiddleStagePhonePK.App.Models.Squidex;

namespace MiddleStagePhonePK.App.Services;

public interface IDataAccessService
{
    Task<SquidexQueryTypes> QueryContentsByIDs(string gqlQueryName, IEnumerable<string> ids, string gqlResultSelector);
    Task<IEnumerable<SquidexMutationTypes>> CreateContents(
        string gqlMutationName,
        string gqlInputTypeName,
        IEnumerable<SquidexPhoneDataInputDto> newItems,
        string gqlResultSelector
    );
}
