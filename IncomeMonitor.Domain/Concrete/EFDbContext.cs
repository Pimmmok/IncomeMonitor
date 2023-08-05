using IncomeMonitor.Domain.Entities;
using System.Data.Entity;

namespace IncomeMonitor.Domain.Concrete
{
    internal class EFDbContext: DbContext
    {
        public DbSet<Procedure> Procecdures { get; set; }
    }
}
