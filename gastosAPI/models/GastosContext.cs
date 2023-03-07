using Microsoft.EntityFrameworkCore;

namespace gastosAPI.models
{
    public class GastosContext: DbContext
    {
        public GastosContext(DbContextOptions<GastosContext> options): base(options)
        {

        }

        public DbSet<Gasto> Gastos =>  Set<Gasto>();   
    }
}
