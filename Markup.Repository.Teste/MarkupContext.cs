using Markup.Models.Teste.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Markup.Data.Teste
{
    public partial class MarkupContext : DbContext
    {
        public MarkupContext()
            : base("name=MarkupContext")
        {
        }

        public virtual DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>()
                .ToTable("Contatos");

            modelBuilder.Entity<Contato>()
                .Property(e => e.Id)
                .HasColumnOrder(0)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasColumnOrder(1)
                .HasMaxLength(150)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Telefone)
                .HasColumnName("Telefone")
                .HasColumnOrder(2)
                .HasMaxLength(150)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Data)
                .HasColumnName("Data")
                .HasColumnOrder(3)
                .HasColumnType("datetime");
        }
    }
}
