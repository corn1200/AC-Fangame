namespace FramePartsInterface
{
    public interface IFrameHeadSpec
    {
        public float AttitudeStability { get; set; }
        public float SystemRecovery { get; set; }
        public float ScanDistance { get; set; }
        public float ScanEffectDuration { get; set; }
        public float ScanWaitingTime { get; set; }
    }
}