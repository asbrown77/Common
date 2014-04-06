using System;
using Common.Service.Interface;
using Common.Service.WcfUnityProvider;
using Microsoft.Practices.Unity;

namespace Common.Service
{
    // TODO : maybe could be done better - i.e. decorator pattern to add wcf behaviour and not inheritence - will do for now
    public abstract class WcfBootstrapperBase : BootstrapperBase<UnityServiceHost>
    {
        private readonly Type serviceType;

        protected WcfBootstrapperBase(IServiceBase underlyingServiceToRegister, Type serviceType)
            : base(underlyingServiceToRegister)
        {
            this.serviceType = serviceType;
        }

        protected override void PerformRegistrations(IUnityContainer container)
        {
            container.RegisterInstance(new UnityServiceHost(container, serviceType));
            PerformRegistrationsAfterServiceHostRegistration(container); 
        }

        protected abstract void PerformRegistrationsAfterServiceHostRegistration(IUnityContainer container);
    }
}
