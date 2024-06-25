namespace MysticExpeditions.Client.Models
{
    public class GameEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Dialogue> Dialogues { get; set; }
        public Dictionary<string, Action> Choices { get; set; }
    }
}