using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Models.Squidex;

namespace MiddleStagePhonePK.App.Services;

public class PhoneService : IPhoneService
{
    private readonly IDataAccessService dataAccessService;

    public PhoneService(IDataAccessService dataAccessService)
    {
        this.dataAccessService = dataAccessService;
    }

    public async Task<List<Phone>> GetByIDs(IEnumerable<string> ids)
    {

        string gqlResultSelector = $@"{{
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

        var data = (await dataAccessService.QueryContentsByIDs(
            "queryPhoneContents",
            ids,
            gqlResultSelector
        )).QueryPhoneContents;

        if (data is null)
        {
            return new List<Phone>();
        }

        var phones =
            from phoneResult in data
            where phoneResult.Data is not null
            select new Phone(
                ID: phoneResult.Id,
                Name: phoneResult.Data!.Name.En,
                Description: phoneResult.Data.Description.En
            );

        return phones.ToList();
    }

    public async Task<IEnumerable<PhoneQueryContentType>> Add(IEnumerable<SquidexPhoneDataInputDto> newItems)
    {

        string gqlResultSelector = "{" +
            $"id" + " " +
            $"createdBy" + " " +
            $"created" +
        "}";

        var responses = await dataAccessService.CreateContents(
            "createPhoneContent",
            "PhoneDataInputDto",
            newItems,
            gqlResultSelector
        );

        return (
            from response in responses
            select response.CreatePhoneContent
        );

    }
}
