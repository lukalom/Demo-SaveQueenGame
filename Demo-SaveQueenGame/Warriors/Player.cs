namespace game
{
    public class Player : GameRules
    {
        public int position;
        public Player()
        {
            DamageRange = 1;
            Damage = 8;
            Hp = 100;
            IsAlive = true;
            position = 0;
        }
    }
}