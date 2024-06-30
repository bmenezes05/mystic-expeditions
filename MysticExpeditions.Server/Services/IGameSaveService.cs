using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Services
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