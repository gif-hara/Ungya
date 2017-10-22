namespace HK.Ungya.CharacterControllers
{
    public sealed class CharacterStatus
    {
        public readonly CharacterSpec.Parameter Base;
        
        public CharacterStatus(CharacterSpec.Parameter parameter)
        {
            this.Base = parameter;
        }
    }
}
