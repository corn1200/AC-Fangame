namespace InnerPartsInterface
{
    public interface IInnerFireControlSystemSpec
    {
        public float ShortDistanceAssistSpecialization { get; set; }
        public float MiddleDistanceAssistSpecialization { get; set; }
        public float LongDistanceAssistSpecialization { get; set; }
        public float MissileAimAdj { get; set; }
        public float MultiAimAdj { get; set; }
        public float Weight { get; set; }
        public float EnergyLoad { get; set; }
    }
}