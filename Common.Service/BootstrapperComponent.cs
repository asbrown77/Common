using System;
using Microsoft.Practices.Unity;

namespace Common.Service
{
    public abstract class BootstrapperComponent<T>
    {
        public abstract T BootstrapAndProvideAService();
        public abstract T BootstrapAndProvideAServiceWithOverrides(Action<IUnityContainer> overrides);
    }
}