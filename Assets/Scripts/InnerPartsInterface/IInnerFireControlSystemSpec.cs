namespace InnerPartsInterface
{
    public interface IInnerFireControlSystemSpec
    {
        public float ShortDistanceAssist { get; set; }
        public float MiddleDistanceAssist { get; set; }
        public float LongDistanceAssist { get; set; }
        public float MissileAimAdj { get; set; }
        public float MultiAimAdj { get; set; }
        public float Weight { get; set; }
        public float EnergyLoad { get; set; }
    }
}