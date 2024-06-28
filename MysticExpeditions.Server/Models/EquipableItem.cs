using MysticExpeditions.Server.Models.Enums;

namespace MysticExpeditions.Server.Models
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