namespace HK.Ungya.CharacterControllers
{
    public sealed class CharacterStatus
    {
        public readonly CharacterSpec.Parameter Base;

        public CharacterSpec.Parameter Instance;
        
        public CharacterStatus(CharacterSpec.Parameter parameter)
        {
            this.Base = parameter;
            this.Instance = parameter;
        }

        public void TakeDamage(int damage)
        {
            this.Instance.HitPoint -= damage;
        }

        public bool IsDead
        {
            get { return this.Instance.HitPoint <= 0.0f; }
        }
    }
}
