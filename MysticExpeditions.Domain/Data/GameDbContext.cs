using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Models;
using MysticExpeditions.Domain.Models.Enums;

namespace MysticExpeditions.Domain.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<AdventureEvent> AdventureEvent { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Chapter> Character { get; set; }
        public DbSet<Choice> Choice { get; set; }
        public DbSet<ChoiceResult> ChoiceResult { get; set; }
        public DbSet<Dialogue> Dialogue { get; set; }
        public DbSet<EquipableItem> Equipment { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Scenario> Scenario { get; set; }
        public DbSet<UsableItem> UsableItem { get; set; }
        public DbSet<GameSave> GameSave { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.ParentClass)
                .WithMany(c => c.SubClasses)
                .HasForeignKey(c => c.ParentClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.Class)
                .WithMany()
                .HasForeignKey(c => c.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.SubClass)
                .WithMany()
                .HasForeignKey(c => c.SubClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Scenario>()
                .HasOne(s => s.Chapter)
                .WithMany(c => c.Scenarios)
                .HasForeignKey(s => s.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdventureEvent>()
                .HasOne(a => a.Scenario)
                .WithMany(s => s.AdventureEvents)
                .HasForeignKey(a => a.ScenarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dialogue>()
                .HasOne(d => d.AdventureEvent)
                .WithMany(a => a.Dialogues)
                .HasForeignKey(d => d.AdventureEventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Choice>()
                .HasOne(c => c.Dialogue)
                .WithMany(d => d.Choices)
                .HasForeignKey(c => c.DialogueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChoiceResult>()
                .HasOne(o => o.Choice)
                .WithMany(c => c.ChoiceResults)
                .HasForeignKey(o => o.ChoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GameSave>()
                .HasOne(gs => gs.Character)
                .WithMany(c => c.GameSaves)
                .HasForeignKey(gs => gs.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GameSave>()
                .HasOne(gs => gs.CurrentChapter)
                .WithMany()
                .HasForeignKey(gs => gs.CurrentChapterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameSave>()
                .HasOne(gs => gs.CurrentScenario)
                .WithMany()
                .HasForeignKey(gs => gs.CurrentScenarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameSave>()
                .HasOne(gs => gs.CurrentAdventureEvent)
                .WithMany()
                .HasForeignKey(gs => gs.CurrentAdventureEventId)
                .OnDelete(DeleteBehavior.Restrict);

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
