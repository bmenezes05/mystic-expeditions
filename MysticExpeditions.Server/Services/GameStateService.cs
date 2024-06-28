using Microsoft.AspNetCore.Components;
using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Services
{
    public class GameStateService
    {
        private readonly NavigationManager _navigationManager;

        public GameStateService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

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

        #region Player Attributes

        public string PlayerName { get; set; }
        public int PlayerHealth { get; set; } = 100;

        #endregion Player Attributes

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

        public void UpdatePlayerHealth(int amount)
        {
            PlayerHealth += amount;
            NotifyStateChanged();
        }

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
            _navigationManager.NavigateTo("/game");
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