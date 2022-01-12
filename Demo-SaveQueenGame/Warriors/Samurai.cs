using System;

namespace game
{
    public class Samurai : GameRules
    {
        static Random r = new Random();
        public Samurai()
        {
            DamageRange = 1;
            Damage = r.Next(3, 8);
            Hp = r.Next(10,20);
            IsAlive = true;
        }
    }
}