namespace QuickBite.API.Controllers;

using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using QuickBite.Domain.Common.Errors;

[ApiController]
public class ApiController : ControllerBase
{
    [HttpGet("problem")]
    public IActionResult Problem(List<Error> errors)
    {
        var error = errors[0];
        var statusCode = error.Type switch
        {
            ErrorType.Failure => StatusCodes.Status400BadRequest,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }
}