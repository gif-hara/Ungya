namespace HK.Ungya.Items
{
    public sealed class Weapon : InstanceItem
    {
        public int Strength { private set; get; }
        
        public int Defence { private set; get; }
        
        public int MoveSpeed { private set; get; }
        
        public int AttackSpeed { private set; get; }
        
        public int Luck { private set; get; }
        
        public Weapon(Item item, WeaponSpec weaponSpec)
            : base(item)
        {
            var parameter = weaponSpec.Parameters[item.SpecId];
            this.Strength = parameter.Strength.Random;
            this.Defence = parameter.Defence.Random;
            this.MoveSpeed = parameter.MoveSpeed.Random;
            this.AttackSpeed = parameter.AttackSpeed.Random;
            this.Luck = parameter.Luck.Random;
        }
    }
}
