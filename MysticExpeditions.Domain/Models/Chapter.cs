using MysticExpeditions.Domain.Models;
namespace MysticExpeditions.Domain.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public DateTime CreatedAt { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public List<Scenario> Scenarios { get; set; }
    }
}
