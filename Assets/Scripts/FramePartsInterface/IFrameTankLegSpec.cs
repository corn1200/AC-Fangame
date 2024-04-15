namespace FramePartsInterface
{
    public interface IFrameTankLegSpec
    {
        public float AttitudeStability { get; set; }
        public float LoadLimit { get; set; }
        public float DrivingPerformance { get; set; }
        public float HighSpeedDrivingPerformance { get; set; }
        public float Thrust { get; set; }
        public float UpwardThrust { get; set; }
        public float UpwardConsumptionEnergy { get; set; }
        public float QuickBoostThrust { get; set; }
        public float QuickBoostSprayTime { get; set; }
        public float QuickBoostConsumptionEnergy { get; set; }
        public float QuickBoostCooldownTime { get; set; }
        public float QuickBoostReusableGuaranteedWeight { get; set; }
        public float AssaultBoostThrust { get; set; }
        public float AssaultBoostConsumptionEnergy { get; set; }
    }
}