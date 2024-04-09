namespace Interface
{
    public interface IDamageable
    {
        public void TakeDamage();
        public void TakeStagger();
        public void RepairDamage();
        public void RepairStagger();
    }
}