using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Counter
{
    public interface ICounter
    {
        Task<CounterRes> GetCounterAsync();
    }
}
