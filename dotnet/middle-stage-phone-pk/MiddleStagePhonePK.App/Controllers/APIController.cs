using Microsoft.AspNetCore.Mvc;
using MiddleStagePhonePK.App.Models;
using MiddleStagePhonePK.App.Services;

namespace MiddleStagePhonePK.App.Controllers;

[Route("[controller]")]
[ApiController]
public class APIController : ControllerBase
{
    private readonly IDataAccessService das;

    public APIController(IDataAccessService das)
    {
        this.das = das;
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
    public async Task<List<PhoneQueryContentType>?> GetPhones()
    {
        var phones = await das.QueryContentsByIDs();

        return phones;
    }
}

