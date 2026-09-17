using Microsoft.AspNetCore.Mvc;

namespace BmsArena.ArenaServer.Controllers;

/**
 *  Don't do this, write a middleware instead.
 *  The API can be written like this, but the entry point for the arena server should probably not be here.
 */

[ApiController]
[Route("/")]
public class ArenaController : ControllerBase
{
    public async Task<IActionResult> Index()
    {
        if (!this.HttpContext.WebSockets.IsWebSocketRequest)
        {
            return BadRequest();
        }

        using var webSocket = await this.HttpContext.WebSockets.AcceptWebSocketAsync();
        await HandleArenaSession();

        return Ok();
    }

    private async Task HandleArenaSession();
}
