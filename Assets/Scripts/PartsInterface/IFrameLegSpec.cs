namespace PartsInterface
{
    public interface IFrameLegSpec
    {
        public float AttitudeStability { get; set; }
        public float LoadLimit { get; set; }
        public float JumpDistance { get; set; }
        public float JumpHeight { get; set; }
    }
}