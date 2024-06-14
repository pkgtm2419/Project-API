using System.Threading.Tasks;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.counter
{
    public interface CounterInterface
    {
        Task<CounterRes> GetCounterAsync();
    }
}
