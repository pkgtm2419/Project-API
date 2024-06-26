﻿using ProjectAPI.SchemaModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.masters.meter
{
    public interface IMeter
    {
        Task<MeterRes> GetMetersAsync();
        Task<MeterRes> GetMetersByMeterIDAsync(int meterID);
    }
}
