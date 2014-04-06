using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Common.Service.WcfLifeTimeManager
{
    public class InstanceItems
    {
        private readonly Dictionary<object, object> items = new Dictionary<object, object>();

        public object Find(object key)
        {
            return items.ContainsKey(key) ? items[key] : null;
        }

        public void Set(object key, object value)
        {
            items[key] = value;
        }

        public void Remove(object key)
        {
            items.Remove(key);
        }

        public void CleanUp(object sender, EventArgs e)
        {
            foreach (IDisposable item in items.Select(item => item.Value).OfType<IDisposable>())
            {
                item.Dispose();
            }
        }

        internal void Hook(InstanceContext instanceContext)
        {
            instanceContext.Closed += CleanUp;
            instanceContext.Faulted += CleanUp;
        }
    }
}