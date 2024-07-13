using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Models
{
    public class GameSave
    {
        public int GameSaveId { get; set; }
        public string PlayerName { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int CurrentChapterId { get; set; }
        public Chapter CurrentChapter { get; set; }
        public int CurrentScenarioId { get; set; }
        public Scenario CurrentScenario { get; set; }
        public int CurrentAdventureEventId { get; set; }
        public AdventureEvent CurrentAdventureEvent { get; set; }
        public DateTime LastSaved { get; set; }
    }
}
