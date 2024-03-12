using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers.Dinners;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}