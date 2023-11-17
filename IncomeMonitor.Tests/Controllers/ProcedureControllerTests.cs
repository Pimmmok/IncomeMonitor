using IncomeMonitor.Domain.Abstract;
using IncomeMonitor.Domain.Entities;
using IncomeMonitor.WebUI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeMonitor.Tests.Controllers
{
    internal class ProcedureControllerTests
    {

        [Test]
        public void List_Contains_All_Procedures()
        {
            // Arrange - create the mock repository
            Mock<IProcedureRepository> mock = new Mock<IProcedureRepository>();
            mock.Setup(m => m.Procedurs).Returns(new List<Procedure> {
        new Procedure{ ProcedureId = 0, Information = "Candy", Value = 25, Note = "Vesta Store", ProcedureDate = DateTime.Now},
            new Procedure{ ProcedureId = 0, Information = "Food", Value = 5, Note = "Evroopt Store", ProcedureDate = DateTime.Now},
            new Procedure{ ProcedureId = 0, Information = "Toy", Value = 37, Note = "Buslic Store", ProcedureDate = DateTime.Now},
            }.AsQueryable());
            ProcedureController target = new ProcedureController(mock.Object);
            Procedure[] result = (target.List().ViewData.Model as IEnumerable<Procedure>).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("Candy", result[0].Information);
            Assert.AreEqual("Food", result[1].Information);
            Assert.AreEqual("Toy", result[2].Information);
        }
    }
}
