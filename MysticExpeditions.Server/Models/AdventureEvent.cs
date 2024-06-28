namespace MysticExpeditions.Server.Models
{
    public class AdventureEvent
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Dialogue> Dialogues { get; set; }

        public int ScenarioId { get; set; }
        public Scenario Scenario { get; set; }
    }
}