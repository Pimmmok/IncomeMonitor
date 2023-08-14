using IncomeMonitor.Domain.Abstract;
using IncomeMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncomeMonitor.Domain.Concrete
{
    public class EFProceduresRepository : IProcedureRepository
    {
        private EFDbContext _context;
        private DbContextOptions<EFDbContext> _contextOptions;
        public EFProceduresRepository(string? connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDbContext>();
            _contextOptions = optionsBuilder.UseSqlServer(connectionString).Options;
            _context = new EFDbContext(_contextOptions);
        }

        public IQueryable<Procedure> Procedurs
        {
            get { return _context.Procedures; }
        }
    }
}
