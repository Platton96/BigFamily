using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Routing;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Abstract;
using Domain.Entities;
using Moq;
using System.Configuration;

namespace WebUI.Infastructure
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

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера 
            // используя его тип
            return controllerType == null
              ? null
              : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            /* Mock<IUserRepository> mock = new Mock<IUserRepository>();
             mock.Setup(m => m.Users).Returns(new List<User> {
           new User { Name = "Football" },
           new User { Name = "Surf board"},
           new User { Name = "Running shoes" }
         }.AsQueryable());

             ninjectKernel.Bind<IUserRepository>().ToConstant(mock.Object);*/
            ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
            ninjectKernel.Bind<IPhotoRepository>().To<EFPhotoRepository>();
           
        }
    }
}