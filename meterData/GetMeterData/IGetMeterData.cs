using ProjectAPI.SchemaModel;
using System.Threading.Tasks;

namespace ProjectAPI.meterData.GetMeterData
{
    public interface IGetMeterData
    {
        Task<string> GetAssociationData(ReqGetMeterData body, List<MeterModel> MeterDetails);
    }
}
