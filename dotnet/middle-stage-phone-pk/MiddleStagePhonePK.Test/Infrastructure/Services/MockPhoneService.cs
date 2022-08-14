using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Models.Squidex;
using MiddleStagePhonePK.App.Services;
using Moq;

namespace MiddleStagePhonePK.Test.Infrastructure.Services;
public class MockPhoneService : PhoneService
{
    public MockPhoneService(): base(SetupMock())
    { }

    public static IDataAccessService SetupMock()
    {
        Mock<IDataAccessService> mock = new();

        mock.Setup(service =>
            service.QueryContentsByIDs(
                It.IsAny<string>(),
                It.IsAny<List<string>>(),
                It.IsAny<string>()
            )
        ).Returns(Task.FromResult(
            new SquidexQueryTypes(
                QueryPhoneContents: new List<PhoneQueryContentType>()
                {
                    new PhoneQueryContentType()
                    {
                        Id = "someguid",
                        Data = new PhoneGraphDataType(
                            Name: new SquidexI18NDto(
                                En: "Pingkang Phone"
                            ),
                            Description: new SquidexI18NDto(
                                En: "Pingkang Phone"
                            )
                        )
                    }
                }
            )
        ));

        return mock.Object;
    }
}
