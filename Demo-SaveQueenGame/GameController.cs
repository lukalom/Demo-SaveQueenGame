using System;
using System.Collections.Generic;

namespace game
{
    public class GameController
    {
        private const int MapRange = 100;
        private readonly Player _player;
        private readonly List<GameRules> _bots = new List<GameRules>();

        public GameController(Player player)
        {
            _player = player;
            GenerateBots();
        }

        public void Run()
        {
            Console.WriteLine(Fight() ? "Queen saved." : "You Lose!");
        }


        private void GenerateBots()
        {
            for (var i = 0; i < MapRange / 10; i++)
            {
                Random r = new();

                if (r.Next(100) <= 50)
                {
                    _bots.Add(new Archer());
                }
                else
                {
                    _bots.Add(new Samurai());
                }
            }
        }

        private void Heal()
        {
            var r = new Random(); //40% chance to heal

            if (r.Next(100) <= 40 && _player.Hp + 10 <= 100)
            {
                if (_player.Hp + 10 >= 100)
                {
                    _player.Hp = 100;
                    Console.WriteLine("Player is full hp");
                }
                else
                {
                    Console.WriteLine("Healed +10hp");
                    _player.Hp += 10;
                }
            }
        }

        private bool Fight()
        {
            for (int i = 0; i < _bots.Count; i++)
            {
                Console.WriteLine($"{_bots[i].GetType().Name} : {i + 1}");
                for (int j = 1; j < _bots[i].DamageRange + 1; j++)
                {
                    _player.position++;
                    Console.WriteLine($"Player position: {_player.position}");

                    if (_player.position == _bots[i].DamageRange)
                    {
                        Console.WriteLine("You See Enemy Fight !");
                        while (_bots[i].IsAlive)
                        {
                            _bots[i].Hp -= _player.Damage;
                            _player.Hp -= _bots[i].Damage;

                            Console.WriteLine($"{_bots[i].GetType().Name} HP {_bots[i].Hp}");
                            Console.WriteLine($"Player HP {_player.Hp}");

                            if (_player.Hp <= 0)
                            {
                                Console.WriteLine("Player Dies");
                                _player.IsAlive = false;
                                return false;
                            }

                            if (_bots[i].Hp <= 0)
                            {
                                Console.WriteLine($"{_bots[i].GetType().Name} dead");
                                _bots[i].IsAlive = false;
                                _player.position = 0;
                                Heal();
                            }
                        }
                        continue;
                    }
                    if (_player.position < _bots[i].DamageRange)
                    {
                        Console.WriteLine($"{_bots[i].GetType().Name} hits you");
                        _player.Hp -= _bots[i].Damage;
                    }
                }
            }
            return true;
        }
    }
}