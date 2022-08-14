using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Services;
using MiddleStagePhonePK.Test.Infrastructure;

namespace MiddleStagePhonePK.Test.PhoneTests;
public class PhoneTest : IClassFixture<ServiceFixture>
{
    private readonly IHost testHost;
    private readonly IPhoneService phoneService;

    public PhoneTest(ServiceFixture fixture)
    {
        testHost = fixture.TestHost;
        phoneService = testHost.Services.GetService<IPhoneService>()!;
    }

    [Theory]
    [ClassData(typeof(PhoneQueryData))]
    public async Task GiveIDs_ReturnPhones(List<string> ids)
    {
        List<Phone> phones = await phoneService.GetByIDs(ids);

        Assert.Single(phones);

        Assert.Equal(ids.First(), phones.First().ID);
    }
}

public class PhoneQueryData : TheoryData<List<string>>
{
    public PhoneQueryData()
    {
        Add(
            new List<string>()
            {
                "someguid"
            }
        );
    }
}
