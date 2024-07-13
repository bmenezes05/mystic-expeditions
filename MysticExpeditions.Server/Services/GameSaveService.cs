using MysticExpeditions.Server.Data.Repositories.Interfaces;
using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Services
{
    public class GameSaveService : IGameSaveService
    {
        private readonly IGameSaveRepository _gameSaveRepository;

        public GameSaveService(IGameSaveRepository gameSaveRepository)
        {
            _gameSaveRepository = gameSaveRepository;
        }

        public async Task<GameSave> CreateNewGameSave(string playerName, Character character)
        {
            var newGameSave = new GameSave
            {
                PlayerName = playerName,
                CharacterId = character.Id,
                CurrentChapterId = 1, // Initial chapter
                CurrentScenarioId = 1, // Initial scenario
                CurrentAdventureEventId = 1, // Initial adventure event
                LastSaved = DateTime.UtcNow,                
            };

            await _gameSaveRepository.AddAsync(newGameSave);
            return newGameSave;
        }

        public async Task SaveProgress(int gameSaveId, string saveData)
        {
            var gameSave = await _gameSaveRepository.GetByIdAsync(gameSaveId);
            if (gameSave != null)
            {
                //gameSave.SaveData = saveData; Posso salvar um Json detalhado do Save
                gameSave.LastSaved = DateTime.UtcNow;
                await _gameSaveRepository.UpdateAsync(gameSave);
            }
        }

        public async Task<GameSave> LoadGameSave(int gameSaveId)
        {
            return await _gameSaveRepository.GetByIdAsync(gameSaveId);
        }

        public async Task DeleteGameSave(int gameSaveId)
        {
            await _gameSaveRepository.DeleteAsync(gameSaveId);
        }

        public async Task<IEnumerable<GameSave>> GetAllGameSaves()
        {
            return await _gameSaveRepository.GetAllAsync();
        }
    }
}