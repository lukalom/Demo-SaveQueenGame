using System;

namespace game
{
    public class Archer : GameRules
    {
        static Random r = new Random();
        public Archer()
        {
            DamageRange = r.Next(2, 7); ;
            Damage = r.Next(2, 6);
            Hp = r.Next(5, 15);
            IsAlive = true;
        }
    }
}