namespace MysticExpeditions.Server.Models
{
    public class Scenario
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }

        public List<AdventureEvent> AdventureEvents { get; set; }

        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}