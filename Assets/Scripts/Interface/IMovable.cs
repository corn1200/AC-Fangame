namespace Interface
{
    public interface IMovable
    {
        public float BoostActive { get; set; }
        public float OveredBoostActive { get; set; }
        public float GroundActive { get; set; }
        public void ToggleBoost();
        public void ToggleOveredBoost();
        public void QuickBoost();
        public void Move();
        public void Jump();
        public void Glide();
    }
}