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

    public async Task<List<Phone>> Add(IEnumerable<SquidexPhoneDataInputDto> newItems)
    {

        string gqlResultSelector = $@"
        {{
            id
		    createdBy
		    created
		    data {{
			    name {{
				    en
			    }}
			    description {{
				    en
			    }}
		    }}
	    }}
        ";

        var responses = await dataAccessService.CreateContents(
            "createPhoneContent",
            "PhoneDataInputDto",
            newItems,
            gqlResultSelector
        );

        return (
            from response in responses
            select new Phone(
                ID: response.CreatePhoneContent!.Id,
                Name: response.CreatePhoneContent.Data!.Name.En,
                Description: response.CreatePhoneContent.Data.Description.En
            )
        ).ToList();

    }

    public async Task<List<Phone>> Update(IDictionary<string, SquidexPhoneDataInputDto> idNewItemMap)
    {

        string gqlResultSelector = $@"
        {{
            id
		    lastModified
		    lastModifiedBy
		    data {{
			    name {{
				    en
			    }}
			    description {{
				    en
			    }}
		    }}
        }}
        ";

        var responses = await dataAccessService.UpdateContents(
            "updatePhoneContent",
            "PhoneDataInputDto",
            idNewItemMap,
            gqlResultSelector
        );

        return (
            from response in responses
            select new Phone(
                ID: response.UpdatePhoneContent!.Id,
                Name: response.UpdatePhoneContent.Data!.Name.En,
                Description: response.UpdatePhoneContent.Data.Description.En
            )
        ).ToList();

    }

    public async Task<List<Phone>> Delete(IEnumerable<string> ids)
    {
        // Get the phones being deleted
        List<Phone> deletingPhones = await GetByIDs(ids);

        string gqlResultSelector = $@"
        {{
            version
        }}
        ";

        var idDeletingItemMap = await dataAccessService.DeleteContents(
            "deletePhoneContent",
            ids,
            gqlResultSelector
        );

        return deletingPhones.Where(
            (ele) => idDeletingItemMap.ContainsKey(ele.ID)
        ).ToList();
    }
}
