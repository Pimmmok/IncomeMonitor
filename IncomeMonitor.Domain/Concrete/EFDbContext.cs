using IncomeMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeMonitor.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
    {
        }

        public DbSet<Procedure> Procedures { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=WIN-46F7MUQL36M;Initial Catalog=IncomeMonitor;Integrated Security=True; TrustServerCertificate=True;");
        //}
    }
}
