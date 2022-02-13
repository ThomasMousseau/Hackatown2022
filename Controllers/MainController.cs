using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Interfaces;

namespace hackatown2022.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : ControllerBase
{

    private readonly ILogger<MainController> _logger;
    private readonly ILogicLayer _logicLayer;
    private readonly ISummarizationSvc _summarizationSvc;

    public MainController(ILogger<MainController> logger, ILogicLayer logicLayer, ISummarizationSvc summarizationSvc)
    {
        _logger = logger;
        _logicLayer = logicLayer;
        _summarizationSvc = summarizationSvc;
    }
    
    [Route("topics")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var res = await _logicLayer.GetAllNews();

        return Ok(res);
    }

    [Route("summary")]
    [HttpGet]
    public async Task<IActionResult> Summary()
    {
        var res = await _summarizationSvc.GetSummary(new string[] { "this is a test" });
        return Ok(res);
    }
}
