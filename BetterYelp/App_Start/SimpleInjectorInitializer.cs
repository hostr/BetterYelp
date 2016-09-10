﻿using BetterYelp.Common;
using BetterYelp.Models;
using BetterYelp.Models.Repositories;
using BetterYelp.Models.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BetterYelp.App_Start
{
    public class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<ILogger, Logger>();
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<DbContext, SearchContext>();
            container.Register<ISearchRepository, SearchRepository>();
            container.Register<IServiceConnectionsRepository, ServiceConnectionsRepository>();
        }
    }
}