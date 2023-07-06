using Microsoft.AspNetCore.Mvc;
using System.ServiceModel.Channels;
using System;
using System.Web.Mvc;
using Ninject;
using Moq;
using IncomeMonitor.Domain.Abstract;
using IncomeMonitor.Domain.Entities;



namespace IncomeMonitor.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected  IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // конфигурирование контейнера
            Mock<IProcedureRepository> mock = new Mock<IProcedureRepository>();
            mock.Setup(m => m.Procedures).Returns(new List<Procedure> {
            new Procedure{ Id = 0, Information = "Food", Value = 25, Notes = "Vesta Store", ProcedureDate = System.DateTime.Now},
            new Procedure{ Id = 0, Information = "Candy", Value = 5, Notes = "Evroopt Store", ProcedureDate = System.DateTime.Now},
            new Procedure{ Id = 0, Information = "Toy", Value = 33, Notes = "Buslic Store", ProcedureDate = System.DateTime.Now},
            }.AsQueryable());
            ninjectKernel.Bind<IProcedureRepository>().ToConstant(mock.Object);


        }
    }

}

