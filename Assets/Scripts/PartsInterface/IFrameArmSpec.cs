namespace PartsInterface
{
    public interface IFrameArmSpec
    {
        public float ArmsLoadLimit { get; set; }
        public float RecoilControl { get; set; }
        public float FirearmSpecialization { get; set; }
        public float MeleeSpecialization { get; set; }
    }
}