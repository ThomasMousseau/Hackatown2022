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

    public MainController(ILogger<MainController> logger, ILogicLayer logicLayer)
    {
        _logger = logger;
        _logicLayer = logicLayer;
    }
    
    [Route("topics")]
    [HttpGet]
    public IActionResult Get()
    {
        var res = _logicLayer.GetAllNews();
        Console.WriteLine("tamer");
        return Ok(res);
    }
}
