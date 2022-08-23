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
    public static Task<List<Phone>> GetPhones()
    {
        return Task.FromResult(new List<Phone>()
        {
            new Phone(ID: "12345", Name: "zuazima phone", Description: "descr")
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
    public static Task<List<Phone>> TestExplodingPhones(string testID)
    {
        return Task.FromResult(new List<Phone>()
        {
            new Phone(ID: testID, Name: "Booooooom!", Description: "[Connection reset...]")
        });
    }
}
