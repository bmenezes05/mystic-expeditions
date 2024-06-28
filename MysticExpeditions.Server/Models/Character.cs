namespace MysticExpeditions.Server.Models
{
    public class Character
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Race { get; set; }
        public required string Class { get; set; }
        public required string SubClass { get; set; }
        public required int Level { get; set; }
        public required int Experience { get; set; }
        public required int Health { get; set; }
        public required int Attack { get; set; }
        public required int Defense { get; set; }
        public required int Luck { get; set; }
        public required bool MainCharacter { get; set; }
        public required bool TeamMember { get; set; }

        public List<EquipableItem> Equipments { get; set; } = new List<EquipableItem>();

    }
}