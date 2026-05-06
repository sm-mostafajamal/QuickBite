namespace QuickBite.API.Controllers;

using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    [HttpGet("problem")]
    public IActionResult Problem(List<Error> errors)
    {
        if(errors.All(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);  

        return Problem(errors[0]);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var err in errors)
        {
            modelStateDictionary.AddModelError(err.Code, err.Description);
        }

        return ValidationProblem(modelStateDictionary);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Failure => StatusCodes.Status400BadRequest,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }
}