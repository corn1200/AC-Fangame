namespace PartsInterface
{
    public interface IFrameCoreSpec
    {
        public float AttitudeStability { get; set; }
        public float BoosterEfficiencyAdj { get; set; }
        public float GeneratorOutputAdj { get; set; }
        public float GeneratorSupplyAdj { get; set; }
    }
}