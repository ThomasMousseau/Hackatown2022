using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace hackatown2022.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : ControllerBase
{

    private readonly ILogger<MainController> _logger;
    private readonly NewsSvc _newsService;

    public MainController(ILogger<MainController> logger, NewsSvc newsSvc)
    {
        _logger = logger;
        _newsService = newsSvc;
    }
    
    [Route("tamer")]
    [HttpGet]
    public IActionResult Get()
    {
        var res = _newsService.getTopNews();
        Console.WriteLine("tamer");
        return Ok(res);
    }
}
