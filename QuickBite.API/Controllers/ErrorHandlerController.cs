using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace QuickBite.API.Controllers;

[Route("/api/error")]
public class ErrorHandlerController : ControllerBase
{
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(title:"An unexpected error occurred.", detail: exception?.Message, statusCode: 500);
    }
}