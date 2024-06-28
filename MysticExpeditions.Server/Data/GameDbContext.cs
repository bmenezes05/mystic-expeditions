using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Server.Models;
using MysticExpeditions.Server.Models.Enums;

namespace MysticExpeditions.Server.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<AdventureEvent> AdventureEvent { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Chapter> Character { get; set; }
        public DbSet<Choice> Choice { get; set; }
        public DbSet<ChoiceResult> ChoiceResult { get; set; }
        public DbSet<Dialogue> Dialogue { get; set; }
        public DbSet<EquipableItem> Equipment { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<Item> Item{ get; set; }
        public DbSet<Scenario> Scenario { get; set; }
        public DbSet<UsableItem> UsableItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdventureEvent>()
                .HasOne(ii => ii.Scenario)
                .WithMany(i => i.AdventureEvents)
                .HasForeignKey(ii => ii.ScenarioId);

            modelBuilder.Entity<Choice>()
                .HasOne(ii => ii.Dialogue)
                .WithMany(i => i.Choices)
                .HasForeignKey(ii => ii.DialogueId);

            modelBuilder.Entity<ChoiceResult>()
                .HasOne(ii => ii.Choice)
                .WithMany(i => i.ChoiceResults)
                .HasForeignKey(ii => ii.ChoiceId);

            modelBuilder.Entity<Dialogue>()
                .HasOne(ii => ii.AdventureEvent)
                .WithMany(i => i.Dialogues)
                .HasForeignKey(ii => ii.AdventureEventId);

            modelBuilder.Entity<Scenario>()
                .HasOne(ii => ii.Chapter)
                .WithMany(i => i.Scenarios)
                .HasForeignKey(ii => ii.ChapterId);

            modelBuilder.Entity<Item>()
                .HasDiscriminator<ItemType>("ItemType")
                .HasValue<EquipableItem>(ItemType.Equipable)
                .HasValue<UsableItem>(ItemType.Usable);

            modelBuilder.Entity<InventoryItem>()
                .HasOne(ii => ii.Inventory)
                .WithMany(i => i.InventoryItens)
                .HasForeignKey(ii => ii.InventoryId);
        }
    }
}