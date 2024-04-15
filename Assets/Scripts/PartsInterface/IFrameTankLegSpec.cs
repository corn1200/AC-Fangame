namespace PartsInterface
{
    public interface IFrameTankLegSpec
    {
        public float AttitudeStability { get; set; }
        public float LoadLimit { get; set; }
        public float DrivingPerformance { get; set; }
        public float HighSpeedDrivingPerformance { get; set; }
        public float DrivingForce { get; set; }
        public float UpwardMomentum { get; set; }
        public float RisingConsumptionEnergy { get; set; }
        public float QuickBoostForce { get; set; }
        public float QuickBoostSprayTime { get; set; }
        public float QuickBoostConsumptionEnergy { get; set; }
        public float QuickBoostCooldownTime { get; set; }
        public float QuickBoostReusableGuaranteedWeight { get; set; }
        public float AssaultBoostForce { get; set; }
        public float AssaultBoostConsumptionEnergy { get; set; }
    }
}