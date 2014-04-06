using System;
using Microsoft.Practices.Unity;

namespace Common.Service.Interface
{
    public interface IBootstrapper<out T> where T : class
    {
        T BootstrapAndProvideAService();
        T BootstrapAndProvideAServiceWithOverrides(Action<IUnityContainer> overrides);
    }
}
