using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Data.Repositories.Interfaces;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Data.Repositories
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(GameDbContext context) : base(context)
        {
        }

        // Implemente métodos específicos do PlayerCharacter, se houver
    }
}
