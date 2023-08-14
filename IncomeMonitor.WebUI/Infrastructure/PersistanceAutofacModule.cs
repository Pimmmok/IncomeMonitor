using Autofac;
using IncomeMonitor.Domain.Abstract;
using IncomeMonitor.Domain.Concrete;
using Moq;

namespace IncomeMonitor.WebUI.Infrastructure
{
    public class PersistanceAutofacModule:Module
    {
        private string? _connectionString;
        public PersistanceAutofacModule(string? connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //Mock<IProcedureRepository> mock = new Mock<IProcedureRepository>();
            //mock.Setup(m => m.Procedures).Returns(new List<Procedure> {
            //new Procedure{ Id = 0, Information = "Food", Value = 25, Notes = "Vesta Store", ProcedureDate = DateTime.Now},
            //new Procedure{ Id = 0, Information = "Candy", Value = 5, Notes = "Evroopt Store", ProcedureDate = DateTime.Now},
            //new Procedure{ Id = 0, Information = "Toy", Value = 33, Notes = "Buslic Store", ProcedureDate = DateTime.Now},
            //}.AsQueryable());
            //builder.RegisterInstance(mock.Object).As<IProcedureRepository>();
            //builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            var eFProceduresRepository = new EFProceduresRepository(_connectionString);
            builder.RegisterInstance(eFProceduresRepository).As<IProcedureRepository>();
            //builder.RegisterInstance<EFProceduresRepository>().As<IProcedureRepository>();

            // Other Lifetime
            // Transient
            //builder.RegisterType<PingPongRepository>().As<IPingPongRepository>()
            //    .InstancePerDependency();

            //// Scoped
            //builder.RegisterType<PingPongRepository>().As<IPingPongRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<PingPongRepository>().As<IPingPongRepository>()
            //    .InstancePerRequest();

            //// Singleton
            //builder.RegisterType<PingPongRepository>().As<IPingPongRepository>()
            //    .SingleInstance();

            // Scan an assembly for components
            //builder.RegisterAssemblyTypes(typeof(AssemblyReference).Assembly)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();
        }
    }
}
