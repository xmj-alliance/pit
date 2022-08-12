using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Models.Squidex;
using MiddleStagePhonePK.App.Services;
using MiddleStagePhonePK.Test.Infrastructure;
using Moq;

namespace MiddleStagePhonePK.Test.CheerUp;

[Collection("Sequential")]
public class CheerUpTest : IClassFixture<ServiceFixture>
{
    private readonly IHost testHost;
    private readonly IDataAccessService dataAccessService;

    public CheerUpTest(ServiceFixture fixture)
    {
        testHost = fixture.TestHost;
        dataAccessService = testHost.Services.GetService<IDataAccessService>()!;
    }

    [Fact]
    public void HaveFun()
    {
        Assert.Equal("😙", "😙");
        Assert.NotNull(dataAccessService);
    }

    [Fact]
    public async void TryingMoq()
    {
        var mock = new Mock<IDataAccessService>();

        mock.Setup(service =>
            service.QueryContentsByIDs(
                "getBlahblahs",
                new List<string>() { "id1" }
                , "{id}"
            )
        ).Returns(
            Task<SquidexQueryTypes>.Factory.StartNew(() =>
                new SquidexQueryTypes(
                    QueryPhoneContents: new List<PhoneQueryContentType>()
                    {
                        new PhoneQueryContentType(
                            Id: "someguid",
                            Version: 1,
                            Created: DateTime.Now,
                            CreatedBy: "me",
                            Data: new PhoneGraphDataType(
                                Name: new SquidexI18NDto(
                                    En: "Pingkang Phone"
                                ),
                                Description: new SquidexI18NDto(
                                    En: "Pingkang Phone"
                                )
                            )
                        )
                    }
                )
            )
        );

        IDataAccessService mockDataAccessService = mock.Object;


        var result = await mockDataAccessService.QueryContentsByIDs(
            "getBlahblahs",
            new List<string>() { "id1" }
            , "{id}"
        );

        Assert.NotNull(result);

        Assert.Equal("someguid", result.QueryPhoneContents[0].Id);


    }

}
