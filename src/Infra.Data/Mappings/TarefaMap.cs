using TaskB3.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskB3.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnType("int") 
                .IsRequired();

            // builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
