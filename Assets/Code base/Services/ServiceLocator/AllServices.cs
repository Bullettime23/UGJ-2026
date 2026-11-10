using System;
using System.Collections.Generic;

namespace LevGamekit.Infrastructure.ServiceLocator
{
    public class AllServices
    {
        private static AllServices instance;
        public static AllServices Container => instance ?? (instance = new AllServices());
        private readonly Dictionary<Type, IService> services = new();

        public void RegisterSingle<TypeService>(TypeService implementation) where TypeService : class, IService
        {
            services.Add(typeof(TypeService), implementation);
        }
        public void Unregister<TypeService>() where TypeService : class, IService
        {
            services.Remove(typeof(TypeService));
        }
        public TypeService Single<TypeService>() where TypeService : class, IService
        {
            if (services.ContainsKey(typeof(TypeService)))
            {
                return services[typeof(TypeService)] as TypeService;
            }
            return null;
        }
    }
}
