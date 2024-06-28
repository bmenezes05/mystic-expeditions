using MysticExpeditions.Server.Models.Enums;

namespace MysticExpeditions.Server.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
    }
}