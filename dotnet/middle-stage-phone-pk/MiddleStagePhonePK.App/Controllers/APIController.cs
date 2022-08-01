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
    public async Task<IEnumerable<PhoneQueryContentType>> AddPhones()
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
}

