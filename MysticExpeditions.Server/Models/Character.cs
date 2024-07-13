namespace MysticExpeditions.Server.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Luck { get; set; }
        public bool MainCharacter { get; set; }
        public bool TeamMember { get; set; }
        public string Gender { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int? SubClassId { get; set; }
        public Class SubClass { get; set; }

        public List<GameSave> GameSaves { get; set; }

        public List<EquipableItem> Equipments { get; set; } = new List<EquipableItem>();
    }
}