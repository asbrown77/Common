namespace Common.Service.Interface
{
    public interface IServiceBase
    {
        void Stop();

        bool CanShutDown { get; }
    }
}
