using GraphQL;
using MiddleStagePhonePK.App.Models;

namespace MiddleStagePhonePK.App.Controllers;

public partial class Query
{
    public Query()
    {
        // Inject services
    }

    [GraphQLMetadata("phones")]
    public Task<List<Phone>> GetPhones(IEnumerable<string> ids)
    {
        Console.WriteLine(ids);
        return Task.FromResult(new List<Phone>()
        {
            new Phone(Id: "12345", Name: "zuazima phone", Description: "descr")
        });
    }

}

public partial class Mutation
{
    public Mutation()
    {
        // Inject services
    }

    [GraphQLMetadata("testExplodingPhones")]
    public Task<List<Phone>> TestExplodingPhones(string testID)
    {
        return Task.FromResult(new List<Phone>()
        {
            new Phone(Id: testID, Name: "Booooooom!", Description: "[Connection reset...]")
        });
    }
}
