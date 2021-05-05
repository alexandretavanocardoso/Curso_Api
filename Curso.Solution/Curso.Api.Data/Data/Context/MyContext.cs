using Curso.Api.Data.Data.Mapping;
using Curso.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curso.Api.Data.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        // Trabalhando com as entidades
        public DbSet<UserEntity> Users { get; set; }


        // Método usado para o mapeamento 
        // Criar tabela, especificar coisas sobre a tabela
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cria o mapeamento no meu context
            modelBuilder.Entity<UserEntity>(new UserMapping().Configure);
        }
    }
}
