using Microsoft.AspNetCore.Mvc;
using proyectoef;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController:  ControllerBase
{
    IHelloWorldService helloWorldService;

    TareaContext dbcontext;

    public HelloWorldController(IHelloWorldService helloWorld, TareaContext db)
    {
        helloWorldService = helloWorld;
        dbcontext = db;
    }
   
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
}