namespace InnerPartsInterface
{
    public interface IInnerGeneratorSpec
    {
        public float EnergyCapacity { get; set; }
        public float EnergyChargingPerformance { get; set; }
        public float SupplyRestorationPerformance { get; set; }
        public float ChargingEnergyUponRestoration { get; set; }
        public float EnergyFirearmSpecialization { get; set; }
        public float Weight { get; set; }
        public float EnergyOutput { get; set; }
    }
}