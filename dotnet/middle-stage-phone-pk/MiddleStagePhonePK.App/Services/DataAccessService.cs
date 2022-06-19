using GraphQL;
using GraphQL.Client.Http;
using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Relay;

namespace MiddleStagePhonePK.App.Services;

public class DataAccessService : IDataAccessService
{
    private readonly GraphQLHttpClient client;
    public DataAccessService(
        IGraphQLClientContext clientContext
    )
    {
        client = clientContext.Client;
    }

    public async Task<QueryTypes> QueryContentsByIDs(string gqlQueryName, IEnumerable<string> ids, string gqlResultSelector)
    {
        string query =
            $"query {gqlQueryName}($filter: String) {{" +
                $"{gqlQueryName}(filter: $filter)" +
                $"{gqlResultSelector}" +
            $"}}";

        IEnumerable<string> quotedIDs = 
            from id in ids
            select $@"'{id}'";

        var gqlRequest = new GraphQLRequest
        {
            Query = query,
            Variables = new
            {
                filter = $@"id in ({string.Join(',', quotedIDs)})"
            }
        };

        var graphQLResponse = await client.SendQueryAsync<QueryTypes>(gqlRequest);

        if (graphQLResponse.Errors?.Length > 0)
        {
            List<string> errors = (
                from error in graphQLResponse.Errors
                select error.Message
            ).ToList();
            throw new ApplicationException($@"GQLErrors: {string.Join("\n", errors)}");
        }

        return graphQLResponse.Data;
    }
}
