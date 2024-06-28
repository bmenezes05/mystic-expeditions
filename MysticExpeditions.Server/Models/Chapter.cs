namespace MysticExpeditions.Server.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Scenario> Scenarios { get; set; }
    }
}