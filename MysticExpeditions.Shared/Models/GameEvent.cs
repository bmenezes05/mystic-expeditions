using MysticExpeditions.Shared.Models;

namespace MysticExpeditions.Shared.Models
{
    public class GameEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Dialogue> Dialogues { get; set; }        
    }
}
