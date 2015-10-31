using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Dependency
{
    /// <summary>
    /// Simple wrapper for unity resolution.
    /// </summary>
    public sealed class DependencyFactory
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Public reference to the unity container
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            _container = container;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <returns>Resolved instance</returns>
        public static T Resolve<T>()
        {
            T ret = default(T);
            ret = Container.Resolve<T>();
            return ret;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <param name="parameters">ResolverOverride params to add custom overriding</param>
        /// <returns>Resolved instance</returns>
        public static T Resolve<T>(params ResolverOverride[] parameters)
        {
            T ret = default(T);
            ret = Container.Resolve<T>(parameters);
            return ret;
        }
    }
}
