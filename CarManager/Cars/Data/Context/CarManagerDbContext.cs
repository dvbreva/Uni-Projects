using Data.Entities;
using System.Data.Entity;

namespace Data.Context
{
    public class CarManagerDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Make> Makes { get; set; }

        public DbSet<Type> Types { get; set; }
    }
}
