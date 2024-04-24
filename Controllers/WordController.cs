using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using webapi.Models;
using webapi.Data;


namespace webapi.Controllers
{
    [Route("api/word")]
    [ApiController]
 
    public class WordController : ControllerBase
    {

        private readonly WordGameContext _context;
        public WordController(WordGameContext context)
        {
            _context = context;            
        }

        [HttpGet]
        public async Task<ActionResult<WordDTO>> GetWord(int wordLength)
        {
            WordGameContext context = new WordGameContext();
            // _logger.LogInformation("Logger is working");
            WordDTO wordDTO = WordStore.GetMockWord();
            
            return wordDTO;
        }
    }
}
