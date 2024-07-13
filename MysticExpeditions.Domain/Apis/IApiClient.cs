using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Apis
{
    public interface IApiClient
    {
        Task<List<Race>> GetRacesAsync();

        Task<List<Class>> GetClassesAsync();

        Task<List<Class>> GetSubclassesAsync();

        Task<HttpResponseMessage> CreateCharacterAsync(Character character);
    }
}