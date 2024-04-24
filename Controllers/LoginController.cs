using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using webapi.Models.DTO;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PuzzleGame")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }


        [HttpPost]

        public async Task<LoginDTO> Login([FromBody] LoginDTO loginDTO)
        {
            WordGameContext context = new WordGameContext();
            LoginDTO outloginDTO = new LoginDTO();


            try
            {
                
                    outloginDTO = await PlayerStore.Login(context, loginDTO);
                
              

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message.ToString());
            }


            return outloginDTO;
        }
    }
}
