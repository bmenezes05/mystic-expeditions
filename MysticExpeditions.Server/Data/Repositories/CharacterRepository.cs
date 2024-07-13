using MysticExpeditions.Server.Data.Repositories.Interfaces;
using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Data.Repositories
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(GameDbContext context) : base(context)
        {
        }

        // Implemente métodos específicos do PlayerCharacter, se houver
    }
}