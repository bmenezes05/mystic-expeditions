using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Domain.Apis;
using MysticExpeditions.Server.Data;
using MysticExpeditions.Server.Data.Repositories;
using MysticExpeditions.Server.Data.Repositories.Interfaces;
using MysticExpeditions.Server.Models;
using System.Net.Http;

namespace MysticExpeditions.Server.Services
{
    public class GameStateService
    {
        private readonly NavigationManager navigationManager;
        private readonly IApiClient _apiClient;
        private readonly IGameSaveService gameSaveService;

        public GameSave CurrentGameSave { get; private set; }

        public GameStateService(NavigationManager navigationManager, IApiClient _apiClient)
        {
            this.navigationManager = navigationManager;
            this._apiClient = _apiClient;
            InitializeEvents();
        }

        private void InitializeEvents()
        {
        }

        #region GameSaves
        public async Task StartNewGame(string playerName, Character character)
        {
            CurrentGameSave = await gameSaveService.CreateNewGameSave(playerName, character);
        }
        public async Task SaveProgress(string saveData)
        {
            if (CurrentGameSave != null)
            {
                await gameSaveService.SaveProgress(CurrentGameSave.GameSaveId, saveData);
            }
        }
        public async Task LoadGame(int gameSaveId)
        {
            CurrentGameSave = await gameSaveService.LoadGameSave(gameSaveId);
        }
        public async Task DeleteGame(int gameSaveId)
        {
            await gameSaveService.DeleteGameSave(gameSaveId);
        }

        public async Task<IEnumerable<GameSave>> GetAllGameSaves()
        {
            return await gameSaveService.GetAllGameSaves();
        }
        #endregion GameSaves

        #region Character
        public void CreatePlayer(int amount)
        {
            NotifyStateChanged();
        }

        public void UpdatePlayer(int amount)
        {
            NotifyStateChanged();
        }

        public async Task<List<Race>> GetRacesAsync()
        {
            return await _apiClient.GetRacesAsync();
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            return await _apiClient.GetClassesAsync();
        }

        public async Task<List<Class>> GetSubclassesAsync()
        {
            return await _apiClient.GetSubclassesAsync();
        }

        public async Task CreateCharacterAsync(Character character)
        {
            var response = await _apiClient.CreateCharacterAsync(character);
            response.EnsureSuccessStatusCode();
        }

        #endregion Character

        #region Inventory

        public List<string> Inventory { get; private set; } = new List<string>();

        public void AddItemToInventory(string item)
        {
            Inventory.Add(item);
            NotifyStateChanged();
        }

        public void RemoveItemFromInventory(string item)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
                AddEventMessage($"You used {item}.");
                NotifyStateChanged();
            }
        }

        #endregion Inventory

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void StartAdventure()
        {
            var rand = new Random();
            CurrentEvent = events[rand.Next(events.Count)];
            AddEventMessage(CurrentEvent.Description);
            NotifyStateChanged();
        }

        private List<AdventureEvent> events;

        public void BackToGameMenu()
        {
            //navigationManager.NavigateTo("/game");
        }

        public AdventureEvent CurrentEvent { get; private set; }

        private void AddEventMessage(string message)
        {
            EventMessages.Add(message);
            NotifyStateChanged();
        }

        public List<string> EventMessages { get; private set; } = new List<string>();
    }
}