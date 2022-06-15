using System.Text.Json;
using System.Text.Json.Serialization;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Mvc;
using MiddleStagePhonePK.App.Models;

namespace MiddleStagePhonePK.App.Controllers;

[Route("[controller]")]
[ApiController]
public class APIController : ControllerBase
{
    private readonly HttpClient client;

    public APIController(IHttpClientFactory factory)
    {
        client = factory.CreateClient("client");
    }

    [HttpGet]
    public CommonMessage GetReadyState()
    {
        return new CommonMessage(
            OK: true,
            Content: "API Works!"
        );
    }

    [HttpGet]
    [Route("/phones")]
    public async Task<GraphQLResponse<ResponseType>> GetPhones()
    {
        var graphQLClient = new GraphQLHttpClient(
            new GraphQLHttpClientOptions
            {
                EndPoint = new Uri($"{client.BaseAddress}/graphql"),
                UseWebSocketForQueriesAndMutations = false
            },
            new SystemTextJsonSerializer(
                new JsonSerializerOptions()
                {
                    Converters = {
                        new JsonStringEnumConverter(new ConstantCaseJsonNamingPolicy(), false)
                    }
                }.SetupImmutableConverter()
            ),
            client
        );

        var gqlRequest = new GraphQLRequest {
            Query = $@"
            {{
                findPhoneContent(id: ""46f3ee81-925e-48ce-a07e-c05e2398035c"") {{
		            id
		            data {{
			            name {{
				            en
			            }}
			            description {{
				            en
			            }}
		            }}
	            }}
            }}
            "
        };

        var graphQLResponse = await graphQLClient.SendQueryAsync<ResponseType>(gqlRequest);

        return graphQLResponse;
    }
}

public class ResponseType
{
    public FindPhoneContentType? FindPhoneContent { get; set; }
}


public class FindPhoneContentType
{
    public string? Id { get; set; }
    public PhoneDataType? Data { get; set; }
}

public class PhoneDataType
{
    public SquidexI18NType? Name { get; set; }
    public SquidexI18NType? Description { get; set; }
}

public class SquidexI18NType
{
    public string? En { get; set; }
}
