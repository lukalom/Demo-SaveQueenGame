using System;
using System.Collections.Generic;

namespace game
{
    public class GameController
    {
        private const int _MapRange = 100;
        private readonly Player _player;

        private readonly List<GameRules> _bots = new List<GameRules>();
        public GameController(Player player)
        {
            _player = player;
            GenerateBots();
        }

        public void Run()
        {
            if (Fight())
            {
                Console.WriteLine("Queen saved.");
            }
        }


        private void GenerateBots()
        {
            for (int i = 0; i < _MapRange / 10; i++)
            {
                Random r = new Random();
                int prob = r.Next(100);

                if (prob <= 50)
                {
                    _bots.Add(new Archer());
                }
                else
                {
                    _bots.Add(new Samurai());
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

                            if (_bots[i].Hp <= 0)
                            {
                                Console.WriteLine($"{_bots[i].GetType().Name} dead");
                                _bots[i].IsAlive = false;
                                _player.position = 0;
                                if (Heal() && _player.Hp + 10 <= 100)
                                {
                                    if (_player.Hp + 10 > 100)
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

                            if (_player.Hp <= 0)
                            {
                                Console.WriteLine("Player Dies");
                                _player.IsAlive = false;
                                break;
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

                if (_player.IsAlive == false)
                {
                    Console.WriteLine("you lose");
                    break;
                }

            }

            if (_player.IsAlive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Heal()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 40;
        }

    }
}