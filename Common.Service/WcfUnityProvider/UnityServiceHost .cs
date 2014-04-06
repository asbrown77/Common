using System;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace Common.Service.WcfUnityProvider
{
    public class UnityServiceHost : ServiceHost
    {
        private readonly IUnityContainer container;

        public UnityServiceHost(IUnityContainer container, Type serviceType)
            : base(serviceType)
        {
            this.container = container;
        }

        protected override void OnOpening()
        {
            if (Description.Behaviors.Find<UnityServiceBehavior>() == null)
            {
                Description.Behaviors.Add(new UnityServiceBehavior(container));
            }

            base.OnOpening();
        }
    }
}
