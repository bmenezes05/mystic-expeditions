namespace MysticExpeditions.Shared.Models
{
    public class Dialogue
    {
        public string CharacterName { get; set; }
        public string Text { get; set; }
        public Dictionary<string, Action> Choices { get; set; }
    }
}
