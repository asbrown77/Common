using System;
using Common.Service.Interface;
using Microsoft.Practices.Unity;

namespace Common.Service
{
    public abstract class BootstrapperBase<T> : IBootstrapper<T> where T : class
    {
        private readonly IServiceBase underlyingServiceToRegister;

        protected BootstrapperBase(IServiceBase underlyingServiceToRegister)
        {
            this.underlyingServiceToRegister = underlyingServiceToRegister;
        }

        protected static LifetimeManager SameInstanceForEveryone
        {
            get
            {
                return new ContainerControlledLifetimeManager();
            }
        }

        public T BootstrapAndProvideAService()
        {
            return BootstrapAndProvideAServiceWithOverrides(overrides => { });
        }

        public T BootstrapAndProvideAServiceWithOverrides(Action<IUnityContainer> overrides)
        {
            var container = new UnityContainer();
            container.RegisterInstance(this.underlyingServiceToRegister);

            PerformRegistrations(container);
            overrides(container);
            PerformRegistrationsAfterPreviousRegistrationsIncludingOverides(container);

            return container.Resolve<T>();
        }

        protected abstract void PerformRegistrations(IUnityContainer container);

        protected abstract void PerformRegistrationsAfterPreviousRegistrationsIncludingOverides(IUnityContainer container);
    }

    ////public class WcfBootstrapper : BootstrapperDecorator<UnityServiceHost>
    ////{
    ////    private readonly Type serviceType;

    ////    public WcfBootstrapper(BootstrapperComponent<UnityServiceHost> bootStrapperComponent, Type serviceType)
    ////        : base(bootStrapperComponent)
    ////    {
    ////        this.serviceType = serviceType;
    ////    }

    ////    public override UnityServiceHost BootstrapAndProvideAServiceWithOverrides(Action<IUnityContainer> overrides)
    ////    {
    ////        return
    ////            base.BootstrapAndProvideAServiceWithOverrides(
    ////                container => container.RegisterInstance(new UnityServiceHost(container, this.serviceType)));
    ////    }
    ////}
}
