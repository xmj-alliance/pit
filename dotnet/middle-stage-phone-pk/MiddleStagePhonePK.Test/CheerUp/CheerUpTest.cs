using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiddleStagePhonePK.App.Services;
using MiddleStagePhonePK.Test.Infrastructure;

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

}
