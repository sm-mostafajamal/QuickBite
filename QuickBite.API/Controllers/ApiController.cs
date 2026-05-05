namespace QuickBite.API.Controllers;

using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuickBite.Domain.Common.Errors;

[ApiController]
public class ApiController : ControllerBase
{
    [HttpGet("problem")]
    public IActionResult Problem(List<Error> errors)
    {
        if(errors.All(error => error.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var err in errors)
            {
                modelStateDictionary.AddModelError(err.Code, err.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }

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