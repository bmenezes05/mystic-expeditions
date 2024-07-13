using MysticExpeditions.Domain.Models;
namespace MysticExpeditions.Domain.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public List<ChoiceResult> ChoiceResults { get; set; }

        public int DialogueId { get; set; }
        public Dialogue Dialogue { get; set; }
    }
}
