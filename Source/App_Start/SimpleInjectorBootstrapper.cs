﻿using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using VirtualAgentAssessment.AutoMapper;
using VirtualAgentAssessment.Domain;
using VirtualAgentAssessment.Logic.Interfaces;
using VirtualAgentAssessment.Logic.Services;
using VirtualAgentAssessment.Models;
using VirtualAgentAssessment.Repositories.Interfaces;
using VirtualAgentAssessment.Repositories.Repositories;
using VirtualAgentAssessment.Validators;

namespace VirtualAgentAssessment
{
    public class SimpleInjectorBootstrapper
    {
        public static void Boot()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //AutoMapper
            MapperConfiguration config = AutoMapperConfig.Configure();
            container.RegisterInstance<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
            // Register your stuff here
            container.Register<IVirtualAgentContext, VirtualAgentContext>(Lifestyle.Scoped);
            container.Register<IPersonService,PersonService>();
            container.Register<IPersonRepository,PersonRepository>();
            container.Register<IValidator<PersonViewModel>,CreatePersonValidator>();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}