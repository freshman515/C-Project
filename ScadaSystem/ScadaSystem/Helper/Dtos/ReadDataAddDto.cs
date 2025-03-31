using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper.Dtos {
    public class ReadDataAddDto : BaseDto {
        #region Control 设备状态
        public bool TotalStart { get; set; }
        public bool TotalStop { get; set; }
        public bool MechanicalReset { get; set; }
        public bool AlarmReset { get; set; }
        public bool IdleRun { get; set; }
        public bool DegreasingStationOpen { get; set; }
        #endregion

        #region Monitor 监控状态
        public bool DegreasingSprayPumpStatus { get; set; }
        public bool DegreasingExhaustFanStatus { get; set; }
        public bool RoughWashSprayPumpStatus { get; set; }
        public bool PhosphatingSprayPumpStatus { get; set; }
        public bool PhosphatingExhaustFanStatus { get; set; }
        public bool FineWashSprayPumpStatus { get; set; }
        public bool MoistureFurnaceInverterStatus { get; set; }
        public bool MoistureFurnaceAirCurtainStatus { get; set; }
        public bool CoolingChamberCentrifugalFanStatus { get; set; }
        public bool CuringFurnaceInverterStatus { get; set; }
        public bool CuringFurnaceAirCurtainStatus { get; set; }
        public bool ConveyorInverterPowerStatus { get; set; }
        public bool ConveyorInverterRunningStatus { get; set; }
        #endregion

        #region Alarms 报警状态
        public bool DegreasingLowLevelAlarm { get; set; }
        public bool RoughWashPumpOverloadAlarm { get; set; }
        public bool RoughWashLowLevelAlarm { get; set; }
        public bool PhosphatingPumpOverloadAlarm { get; set; }
        public bool PhosphatingLowLevelAlarm { get; set; }
        public bool FineWashPumpOverloadAlarm { get; set; }
        public bool FineWashLowLevelAlarm { get; set; }
        public bool MoistureFurnaceTemperatureAlarm { get; set; }
        public bool MoistureFurnaceBurnerAlarm { get; set; }
        public bool MoistureFurnaceGasLeakAlarm { get; set; }
        public bool CoolingChamberFanOverloadAlarm { get; set; }
        public bool CuringFurnaceTemperatureAlarm { get; set; }
        #endregion
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
