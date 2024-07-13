using MysticExpeditions.Domain.Models;
using MysticExpeditions.Domain.Models.Enums;

namespace MysticExpeditions.Domain.Models
{
    public class EquipableItem : Item
    {        
        public int MinLevelRequirement { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Luck { get; set; }                
        public EquipmentType Type { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }

    }
}
