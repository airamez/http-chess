using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HttpChess.Models;
using System.Text.RegularExpressions;


namespace HttpChess.Controllers
{
  [Route("api/game")]
  [ApiController]
  public class GameController : ControllerBase
  {
    private static Dictionary<Guid, Chess> games = new Dictionary<Guid, Chess>();

    [HttpGet("new")]
    public IActionResult NewGame()
    {
      Guid newGameId = Guid.NewGuid();
      games[newGameId] = new Chess();
      return Content(newGameId.ToString(), "text/plain");
    }


    [HttpGet("{id}/{format?}")]
    public IActionResult Game(Guid id, string format = "html")
    {
      if (!games.ContainsKey(id))
      {
        return NotFound();
      }
      Chess game = games[id];
      return format.ToLower() == "text"
        ? Content(game.ToString(), "text/plain; charset=utf-8")
        : Content(game.ToHtml(), "text/html; charset=utf-8");
    }

    [HttpGet("{gameId}/move/{move}/{format?}")]
    public IActionResult MovePiece(Guid gameId, string move, string format = "html")
    {
      if (!games.ContainsKey(gameId))
      {
        return NotFound("Game ID not found.");
      }
      if (!IsValidChessPositions(move))
      {
        return BadRequest("Invalid position format. Use standard chess notation (e.g., E2A7).");
      }
      Chess game = games[gameId];
      game.Move(move.Substring(0, 2), move.Substring(2, 2));
      return format.ToLower() == "text"
        ? Content(game.ToString(), "text/plain; charset=utf-8")
        : Content(game.ToHtml(), "text/html; charset=utf-8");
    }

    private bool IsValidChessPositions(string move)
    {
      return Regex.IsMatch(move, "^[a-h][1-8][a-h][1-8]$", RegexOptions.IgnoreCase);
    }

    [HttpGet("{gameId}/delete")]
    public IActionResult Delete(Guid gameId)
    {
      games.Remove(gameId);
      return NoContent();
    }
  }
}
