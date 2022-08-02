using Microsoft.AspNetCore.Mvc;
using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Models.Squidex;
using MiddleStagePhonePK.App.Services;

namespace MiddleStagePhonePK.App.Controllers;

[Route("[controller]")]
[ApiController]
public class APIController : ControllerBase
{
    private readonly IPhoneService phoneService;

    public APIController(IPhoneService phoneService)
    {
        this.phoneService = phoneService;
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
    public async Task<List<Phone>> GetPhones()
    {
        var phones = await phoneService.GetByIDs(new List<string>() {
            "6ca174b1-a04a-476b-aa84-3320819bd87f",
            "50e8a5bc-2e37-41fd-8242-04cfc2f9d66a",
        });

        return phones;
    }

    [HttpPost]
    [Route("/addPhones")]
    public async Task<List<Phone>> AddPhones()
    {

        IEnumerable<SquidexPhoneDataInputDto> newItems = new List<SquidexPhoneDataInputDto>() {
            new SquidexPhoneDataInputDto(
                name: new SquidexI18NInputDto(
                    en: "iPad"
                ),
                description: new SquidexI18NInputDto(
                    en: "Testing iPad"
                )
            )
        };

        return await phoneService.Add(newItems);
    }

    [HttpPost]
    [Route("/updatePhones")]
    public async Task<List<Phone>> UpdatePhones()
    {
        IDictionary<string, SquidexPhoneDataInputDto> idNewItemMap = new Dictionary<string, SquidexPhoneDataInputDto>()
        {
            ["b6fc37ff-a87f-4bfe-bf70-50664b494340"] = new SquidexPhoneDataInputDto(
                name: new SquidexI18NInputDto(
                    en: "iPad nimi 4"
                ),
                description: new SquidexI18NInputDto(
                    en: "Yes this is iPad nimi gen 4"
                )
            )
        };

        return await phoneService.Update(idNewItemMap);
    }

    [HttpPost]
    [Route("/deletePhones")]
    public async Task<List<Phone>> DeletePhones()
    {
        List<Phone> deletedPhones = await phoneService.Delete(new List<string>()
        {
            "acf3959d-1594-49dc-bbbf-232a76c1334f"
        });

        return deletedPhones;
    }
}

