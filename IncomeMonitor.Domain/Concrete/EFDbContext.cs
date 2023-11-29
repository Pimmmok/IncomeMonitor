using IncomeMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
            var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreater != null)
            {
                // Create Database 
                if (!dbCreater.CanConnect())
                {
                    dbCreater.Create();
                }

                // Create Tables
                if (!dbCreater.HasTables())
                {
                    dbCreater.CreateTables();
                }
            }
        } 
    
        public DbSet<Procedure> Procedures { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=WIN-46F7MUQL36M;Initial Catalog=IncomeMonitor;Integrated Security=True; TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procedure>().HasData(
            new Procedure { ProcedureId = 3, Information = "Candy", Value = 25, Note = "Vesta Store", ProcedureDate = DateTime.Now },
            new Procedure { ProcedureId = 1, Information = "Food", Value = 5, Note = "Evroopt Store", ProcedureDate = DateTime.Now },
            new Procedure { ProcedureId = 2, Information = "Toy", Value = 37, Note = "Buslic Store", ProcedureDate = DateTime.Now });
        }
    }

    }

