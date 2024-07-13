using MysticExpeditions.Domain.Models;
namespace MysticExpeditions.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; } 
        public int GoldAmount { get; set; }       
        public List<InventoryItem> InventoryItens { get; set; }
    }
}
