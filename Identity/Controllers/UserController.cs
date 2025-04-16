using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] User = new[]
    {
        "Netcode", "Hub", "Armando"
    };

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.Delay(4000);
        return Ok(User);
    }
}
