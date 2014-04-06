using System;
using Microsoft.Practices.Unity;

namespace Common.Service.WcfLifeTimeManager
{
    public class WcfServiceInstanceLifeTimeManager : LifetimeManager
    {
        private readonly Guid key;

        public WcfServiceInstanceLifeTimeManager()
        {
            key = Guid.NewGuid();
        }

        public override object GetValue()
        {
            return WcfServiceInstanceExtension.Current.Items.Find(key);
        }

        public override void SetValue(object newValue)
        {
            WcfServiceInstanceExtension.Current.Items.Set(key, newValue);
        }

        public override void RemoveValue()
        {
            WcfServiceInstanceExtension.Current.Items.Remove(key);
        }
    }
}
