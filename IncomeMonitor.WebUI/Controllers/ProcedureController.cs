using Microsoft.AspNetCore.Mvc;
using IncomeMonitor.Domain.Abstract;
using Moq;
using IncomeMonitor.Domain.Entities;

namespace IncomeMonitor.WebUI.Controllers
{
    public class ProcedureController : Controller
    {
        private IProcedureRepository repository;
        public ProcedureController(IProcedureRepository procedureRepository)
        {
            this.repository = procedureRepository;
        }
        //public ProcedureController()
        //{
        //    IKernel ninjectKernel = new StandardKernel();
        //    Mock<IProcedureRepository> mock = new Mock<IProcedureRepository>();
        //    mock.Setup(m => m.Procedures).Returns(new List<Procedure> {
        //    new Procedure{ Id = 0, Information = "Food", Value = 25, Notes = "Vesta Store", ProcedureDate = DateTime.Now},
        //    new Procedure{ Id = 0, Information = "Candy", Value = 5, Notes = "Evroopt Store", ProcedureDate = DateTime.Now},
        //    new Procedure{ Id = 0, Information = "Toy", Value = 37, Notes = "Buslic Store", ProcedureDate = DateTime.Now},
        //    }.AsQueryable());
        //    ninjectKernel.Bind<IProcedureRepository>().ToConstant(mock.Object);
        //    repository = ninjectKernel.Get<IProcedureRepository>();
        //}

        public ViewResult List()
        {
            return View(repository.Procedures);
        }
    }
}
