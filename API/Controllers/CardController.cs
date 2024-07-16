using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.Interface;

namespace API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CardController(ICardService cardService) : ControllerBase
    {
        [HttpPost("create-card")]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardDTO card)
        {
            try
            {
                return Ok(await cardService.CreateCard(card));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("get-card-by-id")]
        public async Task<IActionResult> GetCardById([FromQuery]int cardId)
        {
            try
            {
                return Ok(await cardService.GetCardById(cardId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("get-card-by-user-id")]
        public async Task<IActionResult> GetCardByUserId([FromQuery] int userId)
        {
            try
            {
                return Ok(await cardService.GetCardsByUserId(userId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("remove-card")]
        public async Task<IActionResult> RemoveCard([FromQuery] int cardId)
        {
            try
            {
                return Ok(await cardService.RemoverCard(cardId));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("update-card")]
        public async Task<IActionResult> UpdateCard([FromBody] UpdateCardDTO cardDTO)
        {
            try
            {
                return Ok(await cardService.UpdateCard(cardDTO));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
