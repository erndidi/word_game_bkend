using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.Models.DTO;
namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PuzzleGame")]
    public class LogoutController : Controller
    {
        private readonly ILogger<LoginController> _logger;
 
        public LogoutController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]

        public async Task<string> Logout([FromBody] LoginDTO loginDTO)
        {
            WordGameContext context = new WordGameContext();
            string message = string.Empty;
            string playerid = loginDTO.playerId;


            try
            {
                message = await PlayerStore.UpdatePlayerScore(context, loginDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message.ToString());
            }


            return message;
        }
    }
}
