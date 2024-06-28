namespace MysticExpeditions.Server.Models
{
    public class Dialogue
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string Text { get; set; }
        public List<Choice> Choices { get; set; }

        public int AdventureEventId { get; set; }
        public AdventureEvent AdventureEvent { get; set; }
    }
}