using System;
using TaskB3.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskB3.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskB3.Domain.Models.Tarefa", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                b.Property<DateTime>("Data");

                b.Property<int>("Status")
                    .IsRequired();

                b.Property<string>("Descricao")
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.ToTable("Tarefa");
            });
        }
    }
}
