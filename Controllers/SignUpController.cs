 using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Puzzle_API.Model;
using webapi.Data;
using webapi.Models;
using webapi.Models.DTO;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SignUpController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

            public async Task<PlayerDTO> SignUp([FromBody] SignUpDTO signupDTO)
            {
                WordGameContext context = new WordGameContext();
                PlayerDTO player = new PlayerDTO();
        
                try
                {              
                  player = await PlayerStore.AddPlayerAsync(context, signupDTO);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }


                return player;
            }
        //[HttpPost]
        //public IActionResult Create([FromBody] LoginModel model)
        //{
        //    return View();
        //}
    }
}
