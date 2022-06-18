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

    public async Task<List<PhoneQueryContentType>?> QueryContentsByIDs()
    {
        IEnumerable<string> ids;

        string gqlSelector = $@"{{
            id
            data {{
               name {{
                en
               }}
               description {{
                en
               }}
            }}
        }}";



        string query = $@"
            query queryPhoneContents($filter: String) {{
                queryPhoneContents(filter: $filter)
                {gqlSelector}
            }}
        ";

        string operationName = "QueryContent";

        var gqlRequest = new GraphQLRequest
        {
            Query = query,
            Variables = new
            {
                filter = "id in ('46f3ee81-925e-48ce-a07e-c05e2398035c', '4340f27f-cd6c-47b7-86d0-433f652dd1d4')"
            }
        };


        var graphQLResponse = await client.SendQueryAsync<QueryTypes>(gqlRequest);

        return graphQLResponse.Data?.QueryPhoneContents;
    }
}
