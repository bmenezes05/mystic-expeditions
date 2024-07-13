using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Services
{
    public interface IGameSaveService
    {
        Task<GameSave> CreateNewGameSave(string playerName, Character character);
        Task SaveProgress(int gameSaveId, string saveData);
        Task<GameSave> LoadGameSave(int gameSaveId);
        Task DeleteGameSave(int gameSaveId);
        Task<IEnumerable<GameSave>> GetAllGameSaves();
    }
}
