using System.Threading.Tasks;
using ProjectAPI.SchemaModel;

namespace ProjectAPI.masters.counter
{
    public interface ICounter
    {
        Task<CounterRes> GetCounterAsync();
    }
}
