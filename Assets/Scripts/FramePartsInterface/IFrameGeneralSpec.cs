namespace FramePartsInterface
{
    public interface IFrameGeneralSpec
    {
        public float ArmorPoint { get; set; }
        public float Weight { get; set; }
        public float EnergyLoad { get; set; }
        public float AntiKineticDefence { get; set; }
        public float AntiEnergyDefence { get; set; }
        public float AntiExplosiveDefence { get; set; }
    }
}