using MysticExpeditions.Client.Models;

namespace MysticExpeditions.Client.Services
{
    public class GameStateService
    {
        public GameStateService()
        {
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            events = new List<GameEvent>
            {
                new GameEvent
                {
                    Title = "An Unexpected Encounter",
                    Description = "You encounter a wandering merchant.",
                    Choices = new Dictionary<string, Action>
                    {
                        { "Trade", () => AddItemToInventory("Mystic Artifact") },
                        { "Ignore", () => UpdatePlayerHealth(-5) }
                    },
                    Dialogues = new List<Dialogue>
                    {
                        new Dialogue { CharacterName = "Merchant", Text = "Greetings, traveler! Care to trade?" },
                        new Dialogue { CharacterName = "Player", Text = "What do you have for sale?" },
                        new Dialogue { CharacterName = "Merchant", Text = "I have wares if you have coin." }
                    }
                },
                new GameEvent
                {
                    Title = "Ancient Scroll",
                    Description = "You discovered an Ancient Scroll.",
                    Choices = new Dictionary<string, Action>
                    {
                        { "Trade", () => AddItemToInventory("Ancient Scroll") },
                        { "Ignore", () => UpdatePlayerHealth(-5) }
                    },
                    Dialogues = new List<Dialogue>
                    {
                        new Dialogue { CharacterName = "Friend", Text = "Greetings, traveler! Care to trade?" },
                        new Dialogue { CharacterName = "Player", Text = "What do you have for sale?" },
                        new Dialogue { CharacterName = "Friend", Text = "I have wares if you have coin." }
                    }
                },
                // Adicione mais eventos conforme necessário
            };
        }

        #region Player Attributes

        public string PlayerName { get; set; }
        public int PlayerHealth { get; set; } = 100;

        #endregion Player Attributes

        #region Inventory

        public List<string> Inventory { get; private set; } = new List<string>();

        #endregion Inventory

        public event Action OnChange;

        public void UpdatePlayerHealth(int amount)
        {
            PlayerHealth += amount;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void TriggerRandomEvent()
        {
            var rand = new Random();
            CurrentEvent = events[rand.Next(events.Count)];
            AddEventMessage(CurrentEvent.Description);
            NotifyStateChanged();
        }

        private List<GameEvent> events;

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

        public GameEvent CurrentEvent { get; private set; }

        public void ChooseOption(string option)
        {
            if (CurrentEvent != null && CurrentEvent.Choices.ContainsKey(option))
            {
                CurrentEvent.Choices[option].Invoke();
                CurrentEvent = null; // Clear the event after making a choice
                NotifyStateChanged();
            }
        }

        private void AddEventMessage(string message)
        {
            EventMessages.Add(message);
            NotifyStateChanged();
        }

        public List<string> EventMessages { get; private set; } = new List<string>();
    }
}