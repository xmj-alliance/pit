using MiddleStagePhonePK.App.Models.Squidex;
using MiddleStagePhonePK.App.Services;

namespace MiddleStagePhonePK.Test.Infrastructure.Services;
public class MockDataAccessService : IDataAccessService
{
    public async Task<IEnumerable<SquidexMutationTypes>> CreateContents<T>(string gqlMutationName, string gqlInputTypeName, IEnumerable<T> newItems, string gqlResultSelector)
    {
        throw new NotImplementedException();
    }

    public async Task<IDictionary<string, SquidexMutationTypes>> DeleteContents(string gqlMutationName, IEnumerable<string> ids, string gqlResultSelector)
    {
        throw new NotImplementedException();
    }

    public async Task<SquidexQueryTypes> QueryContentsByIDs(string gqlQueryName, IEnumerable<string> ids, string gqlResultSelector)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SquidexMutationTypes>> UpdateContents<T>(string gqlMutationName, string gqlInputTypeName, IDictionary<string, T> idNewItemMap, string gqlResultSelector)
    {
        throw new NotImplementedException();
    }
}
