using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper.Dtos
{
    public class QueryPagingReadDataResultDto:BaseDto
    {
        public float DegreasingSprayPumpPressure { get; set; }
        public float DegreasingPhValue { get; set; }
        public float RoughWashSprayPumpPressure { get; set; }
        public float PhosphatingSprayPumpPressure { get; set; }
        public float PhosphatingPhValue { get; set; }
        public float FineWashSprayPumpPressure { get; set; }
        public float MoistureFurnaceTemperature { get; set; }
        public float CuringFurnaceTemperature { get; set; }
        public float FactoryTemperature { get; set; }
        public float FactoryHumidity { get; set; }
        public float ProductionCount { get; set; }
        public float DefectiveCount { get; set; }
        public float ProductionPace { get; set; }
        public float AccumulatedAlarms { get; set; }


    
    }
}
