using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOPPuke3
{
    internal class CounterTerroristTeam
    {
        private List<Player> _counterTerrorists;
        private int _killChance = 7;
        private int _defusingTime = 5;
        public CounterTerroristTeam()
        {
            _counterTerrorists = new List<Player>
            {
                new Player(),
                new Player(),
                new Player(),
                new Player(),
                new Player(),
            };

        }
        public void RemoveCounterTerrorist()
        {
            foreach (var player in _counterTerrorists)
            {
                if (!player.isDead)
                {
                    player.setDead();
                    break;
                }
            }
        }
        public bool AllDead()
        {
            return _counterTerrorists.All(terrorist => terrorist.isDead);
        }

        public void KillTerrorist(TerroristTeam tTeam)
        {
            if (CheckIfSuccesful.IsSuccessful(_killChance))
            {
                tTeam.RemoveTerrorist();
                Console.WriteLine(@"Ct's killed a terrorist.
");
                if (tTeam.AllDead() && !tTeam.BombIsPlanted)
                {
                    Console.WriteLine(@"Counter terrorists win, last terror was killed.");
                    Environment.Exit(0);
                }
            }
            else Console.WriteLine(@$"Ct's attempted to kill some t's, but failed.
");
        }

        public void CounterTerroristAction(TerroristTeam tTeam)
        {
            
            if (tTeam.BombIsPlanted)
            {
                _killChance = 3;
                if (tTeam.AllDead())
                {
                    DefuseBomb();
                }
                else KillTerrorist(tTeam);
            }
            else KillTerrorist(tTeam);
        }

        public void DefuseBomb()
        {
            
            {
                _defusingTime--;
                if (_defusingTime == 0)
                {
                    Console.WriteLine("bomb defuse wow CT WINS!");
                    Environment.Exit(0);
                    return;
                }
                Console.WriteLine(@$"ct are defusing the bomb, {_defusingTime} seconds left.
");
            }
            
        }
    }
}
