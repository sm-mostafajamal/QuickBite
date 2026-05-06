using Microsoft.AspNetCore.Mvc;

namespace QuickBite.API.Controllers;

[Route("api")]
public class DinnerController : ApiController
{
    [HttpGet]
    [Route("dinners")]
    public IActionResult GetDinners()
    {
        return Ok(Array.Empty<string>());
    }
}