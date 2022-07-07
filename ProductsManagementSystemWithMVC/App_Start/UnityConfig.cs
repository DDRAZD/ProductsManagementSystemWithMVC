using System;

using Unity;
using Company.ServiceContracts;
using Company.ServiceLayer;
using Company.RepositoryContracts;
using Company.RepositoryLayer;

namespace ProductsManagementSystemWithMVC
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

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
             container.RegisterType<IProductService,ProductService >();//this will allow dependancy injection, creation of an instance in one place and injecting it in another so they are not tightly bound
            //this means that in any place there is a controller constructor that calls IProductService, an instance of ProductService will be injected (autoamtically create an instance of it) and pass it as an argumnet
            container.RegisterType<IProductsRepository, ProductRepository>();//another mapping; telling that at run time once will be injected vs. the other
        }
    }
}