namespace InnerPartsInterface
{
    public interface IInnerAssaultExpansionSpec
    {
        public float AttackPower { get; set; }
        public float ImpactPower { get; set; }
        public float ImpactResidual { get; set; }
        public float ExplosionRange { get; set; }
        public float EffectArea { get; set; }
        public float DirectHitCompensation { get; set; }
    }
}