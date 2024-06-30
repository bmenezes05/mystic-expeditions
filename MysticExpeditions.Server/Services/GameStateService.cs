using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Server.Data;
using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Services
{
    public class GameStateService
    {
        private readonly NavigationManager navigationManager;
        private readonly IGameSaveService gameSaveService;

        public GameSave CurrentGameSave { get; private set; }

        public GameStateService(NavigationManager navigationManager, IGameSaveService gameSaveService)
        {
            this.gameSaveService = gameSaveService;
            this.navigationManager = navigationManager;
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            events = new List<AdventureEvent>
            {
                new AdventureEvent
                {
                    Title = "An Unexpected Encounter",
                    Description = "You encounter a wandering merchant.",
                    Dialogues = new List<Dialogue>
                    {
                        new Dialogue {
                            CharacterName = "Merchant",
                            Text = "Greetings, traveler! Care to trade?"
                        },
                        new Dialogue {
                            CharacterName = "Player",
                            Text = "What do you have for sale?"
                        },
                        new Dialogue {
                            CharacterName = "Merchant",
                            Text = "I have wares if you have coin. Do you want to trade?"
                        }
                    }
                },
                new AdventureEvent
                {
                    Title = "An Unexpected Encounter",
                    Description = "You encounter a wandering merchant.",
                    Dialogues = new List<Dialogue>
                    {
                        new Dialogue {
                            CharacterName = "Merchant",
                            Text = "Greetings, traveler! Care to trade?"
                        },
                        new Dialogue {
                            CharacterName = "Player",
                            Text = "What do you have for sale?"
                        },
                        new Dialogue {
                            CharacterName = "Merchant",
                            Text = "I have wares if you have coin. Do you want to trade?"
                        }
                    }
                },
            };
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
            navigationManager.NavigateTo("/game");
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