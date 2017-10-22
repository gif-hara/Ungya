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
            this.Instance.hitPoint -= damage;
        }

        public bool IsDead
        {
            get { return this.Instance.hitPoint <= 0.0f; }
        }
    }
}
