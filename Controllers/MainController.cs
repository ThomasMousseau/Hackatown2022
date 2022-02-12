using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Logic;

namespace hackatown2022.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : ControllerBase
{

    private readonly ILogger<MainController> _logger;
    private readonly LogicLayer _logicLayer;

    public MainController(ILogger<MainController> logger, LogicLayer logicLayer)
    {
        _logger = logger;
        _logicLayer = logicLayer;
    }
    
    [Route("tamer")]
    [HttpGet]
    public IActionResult Get()
    {
        var res = _logicLayer.GetAllNews();
        Console.WriteLine("tamer");
        return Ok(res);
    }
}
