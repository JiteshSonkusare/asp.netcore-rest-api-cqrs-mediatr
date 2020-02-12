using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Texts.API.Domain.Entities
{
    public partial class ContractingTextsContext : DbContext
    {
        public ContractingTextsContext()
        {
        }

        public ContractingTextsContext(DbContextOptions<ContractingTextsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Text> Text { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Text>(entity =>
            {
                entity.HasIndex(e => e.TextId)
                    .HasName("IX_Text_Key")
                    .IsUnique();

                entity.Property(e => e.TextId).ValueGeneratedNever();

                entity.Property(e => e.Area).HasMaxLength(100);

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
