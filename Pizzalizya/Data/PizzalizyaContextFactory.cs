using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pizzalizya.Data
{

    public class PizzalizyaContextFactory : IDesignTimeDbContextFactory<PizzalizyaContext>
    {
        public PizzalizyaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzalizyaContext>();

            // 2. Esta é a ÚNICA parte que você precisa garantir que está correta.
            // É a mesma connection string do seu appsettings.json.
            var connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=pizzalizya; Integrated Security=SSPI; TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);

            // 3. Isso cria o contexto usando o construtor que recebe 'options'
            return new PizzalizyaContext(optionsBuilder.Options);
        }
    }
}
