using Microsoft.AspNetCore.Mvc;
using MysticExpeditions.Domain.Data.Repositories.Interfaces;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {            
            _characterRepository = characterRepository;
        }


        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(Character characterModel)
        {
            var character = new Character
            {
                Name = characterModel.Name,
                Gender = characterModel.Gender,
                RaceId = characterModel.RaceId,
                ClassId = characterModel.ClassId,                
            };

            await _characterRepository.AddAsync(character);            

            return CreatedAtAction(nameof(CreateCharacter), new { id = character.Id }, character);
        }
    }
}