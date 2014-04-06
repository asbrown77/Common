using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace Common.Service.WcfUnityProvider
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer container;
        private readonly Type serviceType;

        public UnityInstanceProvider(IUnityContainer container, Type serviceType)
        {
            this.container = container;
            this.serviceType = serviceType;
        }

        public Object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public Object GetInstance(InstanceContext instanceContext, Message message)
        {
            return container.Resolve(serviceType);
        }

        /// <summary>
        /// Called when an <see cref="T:System.ServiceModel.InstanceContext"/> object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">The service's instance context.</param>
        /// <param name="instance">The service object to be recycled.</param>
        public void ReleaseInstance(InstanceContext instanceContext, Object instance)
        {
            container.Teardown(instance);
        }
    }
}
