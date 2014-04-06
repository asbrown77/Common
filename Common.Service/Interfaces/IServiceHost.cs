using System.ServiceModel;

namespace Common.Service.Interface
{
    public interface IServiceHost
    {
        CommunicationState CommunicationState { get; }
        ServiceHost ServiceHost { get; }
        bool ServiceStarted { get; }
        void Start();
        void Stop();
    }
}