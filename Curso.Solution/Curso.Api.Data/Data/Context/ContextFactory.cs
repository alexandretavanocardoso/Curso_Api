using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Curso.Api.Data.Data.Context
{
    // Fabrica de contexto
    // Serve para ciar banco, tabela em tempo "real"
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        // Cria o context
        public MyContext CreateDbContext(string[] args)
        {
            // Configuração para migração
            var connectionString = "Persist Security Info=False;Initial Catalog=API;Server=DESKTOP-HSS7F3O\\SQLEXPRESS;Integrated Security=true;";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
