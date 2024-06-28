namespace MysticExpeditions.Server.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }         
        public int ItemId { get; set; }
        
        // Chave estrangeira para Inventory
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}