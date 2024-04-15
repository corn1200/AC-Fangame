namespace InnerPartsInterface
{
    public interface IInnerBoosterSpec
    {
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
        public float MeleeAttackThrust { get; set; }
        public float MeleeAttackConsumptionEnergy { get; set; }
        public float Weight { get; set; }
        public float EnergyLoad { get; set; }
    }
}