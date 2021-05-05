using Curso.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Curso.Api.Data.Data.Mapping
{
    // Mapeamento da tabela antes de ser criada no banco
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // Configurando o mapeamento
            builder.ToTable("User"); // Nome Tabela

            builder.HasKey(p => p.Id); // Primary Key

            // Campos
            builder.HasIndex(p => p.Email)
                .IsUnique();


            // Propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(p => p.Email)
                .HasMaxLength(100);
        }
    }
}
