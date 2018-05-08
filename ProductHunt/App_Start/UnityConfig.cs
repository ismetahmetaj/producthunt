using System;
using ProductHunt.Data;
using ProductHunt.Data.IRepository;
using ProductHunt.Data.Repository;
using ProductHunt.Service.IServices;
using ProductHunt.Service.Services;
using Unity;
using Unity.AspNet.Mvc;

namespace ProductHunt
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion


        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ApplicationDbContext>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IArticleRepository, ArticleRepository>();
            container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<ICategoryService, CategoryService>();
        }
    }
}