using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOPPuke3
{
    internal class TerroristTeam
    {
        private List<Player> _terrorists;
        private bool _attemptKill;
        private bool _foundBombsite;
        private int _planting = 5;
        public bool BombIsPlanted { get; private set; }

        public TerroristTeam()
        {
            _terrorists = new List<Player>
            {
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player()
            };
        }

        public bool AllDead()
        {
            return _terrorists.All(terrorist => terrorist.isDead);
        }

        public void FindBombSite()
        {
            _foundBombsite = CheckIfSuccesful.IsSuccessful(10);
            Console.WriteLine(!_foundBombsite
                ? @$"Terrorists tried but failed to find bombsite.
"
                : @"Terrorist's found site A.
");
        }

        public void KillCounterTerrorist(CounterTerroristTeam ctTeam)
        {
            if (CheckIfSuccesful.IsSuccessful(7))
            {
                ctTeam.RemoveCounterTerrorist();
                Console.WriteLine(@"Terrorist's killed a ct.
");
                if (ctTeam.AllDead())
                {
                    Console.WriteLine(@"Terrorists win, all cts are dead.");
                    Environment.Exit(0);
                }
            }
            else Console.WriteLine(@$"Terrorist's attempted to kill some ct's, but failed.
");
        }

        public void PlantBomb()
        {
            _planting--;
            if (_planting == 0)
            {
                BombIsPlanted = true;
                Console.WriteLine(@"Terrorist's planted bomb at A.
");
                return;
            }
            Console.WriteLine(@$"terrorists are planting the bomb, {_planting} seconds left.
");
        }

        public void TerroristAction(CounterTerroristTeam ctTeam)
        {
            if (_foundBombsite && !BombIsPlanted)
            {
                PlantBomb();
                return;
            }
            if (_attemptKill)
            {
                KillCounterTerrorist(ctTeam);
                if(!_foundBombsite) _attemptKill = false;

            }
            else
            {
                FindBombSite();
                _attemptKill = true;
            }

        }

        public void RemoveTerrorist()
        {
            {
                foreach (var player in _terrorists)
                {
                    if (!player.isDead)
                    {
                        player.setDead();
                        break;
                    }
                }
            }
        }


        public static void BombExplodes()
        {
            Console.WriteLine(@"BOOM BANG KABLAAAAAM POOW
");
            Thread.Sleep(100);
            Console.WriteLine(@"Terrorists win
");
            Environment.Exit(0);
        }
    }
}
